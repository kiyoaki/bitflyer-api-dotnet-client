using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Utf8Json;
#if NET45
using System.Net;
#endif

namespace BitFlyer.Apis
{
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

        public async Task Subscribe<T>(string channel, Action<T> onReceive, Action onConnect, Action<string, Exception> onError)
        {
            await clientWebSocket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);

            await SendMessageAsync(channel).ConfigureAwait(false);

            var buffer = new byte[ReceiveChunkSize];

            try
            {
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

            var sendingMessage = JsonSerializer.Serialize(new
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

        public void Dispose()
        {
            if (!disposed)
            {
                if (clientWebSocket != null)
                    clientWebSocket.Dispose();

                disposed = true;
            }
        }
    }
}
