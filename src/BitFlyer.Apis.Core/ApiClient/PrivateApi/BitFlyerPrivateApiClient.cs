using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPrivateApiClient
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

        internal async Task<T> Get<T>(string path, Dictionary<string, object> query = null)
        {
            return await SendRequest<T>(HttpMethod.Get, path, query);
        }

        internal async Task<T> Post<T>(string path, string body)
        {
            return await SendRequest<T>(HttpMethod.Post, path, null, body);
        }

        internal async Task<T> Post<T>(string path, Dictionary<string, object> query, string body)
        {
            return await SendRequest<T>(HttpMethod.Post, path, query, body);
        }

        private async Task<T> SendRequest<T>(HttpMethod method, string path,
            Dictionary<string, object> query = null, string body = "")
        {
            string queryString = string.Empty;
            if (query != null)
            {
                queryString = query.ToQueryString();
            }

            using (var message = new HttpRequestMessage(method, path + queryString))
            {
                if (!string.IsNullOrEmpty(body))
                {
                    message.Content = new StringContent(body, Encoding.UTF8, "application/json");
                }
                var timestamp = DateTimeOffset.UtcNow.ToUnixTime().ToString();
                var hash = SignWithHmacsha256(timestamp + method + path + query);
                message.Headers.Add("ACCESS-KEY", _apiKey);
                message.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                message.Headers.Add("ACCESS-SIGN", hash);

                try
                {
                    var response = await HttpClient.SendAsync(message);
                    var json = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var error = JsonConvert.DeserializeObject<Error>(json);
                        if (!string.IsNullOrEmpty(error?.ErrorMessage))
                        {
                            throw new BitFlyerApiException(path, error.ErrorMessage, error);
                        }
                        throw new BitFlyerApiException(path,
                            $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                    }

                    return JsonConvert.DeserializeObject<T>(json);
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
