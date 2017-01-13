using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BitFlyer.Apis.Core.Exceptions;
using BitFlyer.Apis.Core.Extensions;

namespace BitFlyer.Apis.Core
{
    public class BitFlyerPrivateApiClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private static volatile BitFlyerPrivateApiClient _instance;
        private static readonly object SyncRoot = new object();

        private readonly string _apiKey;
        private readonly byte[] _apiSecret;

        private BitFlyerPrivateApiClient(string apiKey, string apiSecret, TimeSpan? timeout)
        {
            _apiKey = apiKey;
            _apiSecret = Encoding.UTF8.GetBytes(apiSecret);
            HttpClient.BaseAddress = BitFlyerConstants.BaseUri;
            HttpClient.Timeout = timeout ?? TimeSpan.FromSeconds(10);
        }

        public static BitFlyerPrivateApiClient GetInstance(string apiKey, string apiSecret, TimeSpan? timeout = null)
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new BitFlyerPrivateApiClient(apiKey, apiSecret, timeout);
                }
            }

            return _instance;
        }

        public async Task<string> Get(string path, string query)
        {
            return await SendRequest(HttpMethod.Get, path, query);
        }

        public async Task<string> Post(string path, string body)
        {
            return await SendRequest(HttpMethod.Post, path, "", body);
        }

        public async Task<string> Post(string path, string query, string body)
        {
            return await SendRequest(HttpMethod.Post, path, query, body);
        }

        private async Task<string> SendRequest(HttpMethod method, string path, string query, string json = "")
        {
            using (var message = new HttpRequestMessage(method, path + query)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            })
            {
                var timestamp = DateTimeOffset.UtcNow.ToUnixTime().ToString();
                var hash = SignWithHmacsha256(timestamp + method + path + query);
                message.Headers.Add("ACCESS-KEY", _apiKey);
                message.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                message.Headers.Add("ACCESS-SIGN", hash);

                try
                {
                    var response = await HttpClient.SendAsync(message);
                    return await response.Content.ReadAsStringAsync();
                }
                catch (TaskCanceledException)
                {
                    throw new BitFlyerApiException(path, "Request Timeout");
                }
            }
        }

        private string SignWithHmacsha256(string data)
        {
            using (var encoder = new HMACSHA256(_apiSecret))
            {
                var hash = encoder.ComputeHash(Encoding.UTF8.GetBytes(data));
                return ToHexString(hash);
            }
        }

        private static string ToHexString(IReadOnlyCollection<byte> bytes)
        {
            var sb = new StringBuilder(bytes.Count * 2);
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
