using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
#if NET45
using System.Net;
#endif

namespace BitFlyer.Apis;

public sealed class RealtimeApi : IDisposable
{
    private const int ReceiveChunkSize = 1024;
    private const int SendChunkSize = 1024;
    private static readonly Uri uri = new Uri("wss://ws.lightstream.bitflyer.com/json-rpc");
    private readonly ClientWebSocket clientWebSocket;
    private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private readonly CancellationToken cancellationToken;
    private readonly int clientId;
    private bool disposed;

    public RealtimeApi()
    {
#if NET45
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
        clientWebSocket = new ClientWebSocket();
        clientWebSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(20);
        cancellationToken = cancellationTokenSource.Token;
        clientId = new Random().Next(1, int.MaxValue - 1);
    }

    public async Task Subscribe<T>(string channel, Action<T> onReceive, Action onConnect, Action<string, Exception?> onError, string? key = null, string? secret = null)
    {
        await clientWebSocket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);

        try
        {
            if ((key != null) && (secret != null))
            {
                await SendAuthMessageAsync(key, secret).ConfigureAwait(false);
                var buffer_auth = new byte[ReceiveChunkSize];

                while (clientWebSocket.State == WebSocketState.Open)
                {
                    var resultBuffer = new List<byte>();

                    WebSocketReceiveResult result;
                    do
                    {
                        result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer_auth), cancellationToken).ConfigureAwait(false);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).ConfigureAwait(false);
                            onError("closed", null);
                        }
                        else
                        {
                            resultBuffer.AddRange(buffer_auth.Take(result.Count));
                        }
                    } while (!result.EndOfMessage);

                    var message = JsonSerializer.Deserialize<RealtimeJsonRpc<T>>(resultBuffer.ToArray());

                    if (message != null && message.Id == clientId)
                    {
                        if (message.Result == true)
                        {
                            break;
                        }
                    }
                }
            }

            await SendMessageAsync(channel).ConfigureAwait(false);
            var buffer = new byte[ReceiveChunkSize];

            while (clientWebSocket.State == WebSocketState.Open)
            {
                var resultBuffer = new List<byte>();

                WebSocketReceiveResult result;
                do
                {
                    result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None).ConfigureAwait(false);
                        onError("closed", null);
                    }
                    else
                    {
                        resultBuffer.AddRange(buffer.Take(result.Count));
                    }
                } while (!result.EndOfMessage);

                var message = JsonSerializer.Deserialize<RealtimeJsonRpc<T>>(resultBuffer.ToArray());

                if (message != null)
                {
                    if (message.Id == clientId)
                    {
                        onConnect();
                    }
                    if (message.Params != null && message.Params.Message != null)
                    {
                        onReceive(message.Params.Message);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            onError(ex.Message, ex);
        }
        finally
        {
            clientWebSocket.Dispose();
        }
    }

    private async Task SendMessageAsync(string channel)
    {
        if (clientWebSocket.State != WebSocketState.Open)
        {
            throw new InvalidOperationException("Connection is not open.");
        }

        var sendingMessage = JsonSerializer.SerializeToUtf8Bytes(new
        {
            method = "subscribe",
            @params = new { channel },
            id = clientId
        });

        var messagesCount = (int)Math.Ceiling((double)sendingMessage.Length / SendChunkSize);

        for (var i = 0; i < messagesCount; i++)
        {
            var offset = SendChunkSize * i;
            var count = SendChunkSize;
            var lastMessage = (i + 1) == messagesCount;

            if ((count * (i + 1)) > sendingMessage.Length)
            {
                count = sendingMessage.Length - offset;
            }

            await clientWebSocket.SendAsync(new ArraySegment<byte>(sendingMessage, offset, count), WebSocketMessageType.Text, lastMessage, cancellationToken).ConfigureAwait(false);
        }
    }

    private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

    public static long GetUnixTime(DateTime targetTime)
    {
        targetTime = targetTime.ToUniversalTime();
        TimeSpan elapsedTime = targetTime - UNIX_EPOCH;
        return (long)elapsedTime.TotalSeconds;
    }
    private static string GenerateNonce(int length)
    {
#if NET6_0_OR_GREATER
        var buffer = RandomNumberGenerator.GetBytes(length);
#else
        var rnd = new RNGCryptoServiceProvider();
        var buffer = new byte[length];
        rnd.GetBytes(buffer);
#endif
        string nonce = "";
        foreach (char letter in buffer.Select(v => (char)v))
        {
            int value = Convert.ToInt32(letter);
            nonce += value.ToString("X");
        }
        return nonce.ToLower();
    }
    private byte[] ComputeHmacSha256(byte[] inputByteList, byte[] key)
    {
        using (var hmacSha256 = new HMACSHA256(key))
        {
            return hmacSha256.ComputeHash(inputByteList);
        }
    }

    private async Task SendAuthMessageAsync(string key, string secret)
    {
        if (clientWebSocket.State != WebSocketState.Open)
        {
            throw new InvalidOperationException("Connection is not open.");
        }

        DateTime targetTime = DateTime.Now;
        long unixTime = GetUnixTime(targetTime);

        string nonce = GenerateNonce(16);

        var inputByteList = Encoding.UTF8.GetBytes(unixTime.ToString() + nonce);
        var hmackey = Encoding.UTF8.GetBytes(secret);
        var outputByteList = ComputeHmacSha256(inputByteList, hmackey);

        var sendingMessage = JsonSerializer.SerializeToUtf8Bytes(new
        {
            method = "auth",
            @params = new
            {
                api_key = key,
                timestamp = unixTime,
                nonce,
                signature = BitConverter.ToString(outputByteList).Replace("-", string.Empty).ToLower()
            },
            id = clientId
        });

        var messagesCount = (int)Math.Ceiling((double)sendingMessage.Length / SendChunkSize);

        for (var i = 0; i < messagesCount; i++)
        {
            var offset = SendChunkSize * i;
            var count = SendChunkSize;
            var lastMessage = (i + 1) == messagesCount;

            if ((count * (i + 1)) > sendingMessage.Length)
            {
                count = sendingMessage.Length - offset;
            }

            await clientWebSocket.SendAsync(new ArraySegment<byte>(sendingMessage, offset, count), WebSocketMessageType.Text, lastMessage, cancellationToken).ConfigureAwait(false);
        }
    }

    public void Dispose()
    {
        if (!disposed)
        {
            clientWebSocket?.Dispose();
            disposed = true;
        }
    }
}
