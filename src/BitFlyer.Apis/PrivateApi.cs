using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = BitFlyerConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(10)
        };

        private readonly string _apiKey;
        private readonly byte[] _apiSecret;

        public PrivateApi(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = Encoding.UTF8.GetBytes(apiSecret);
        }

        internal async Task<T> Get<T>(string path, Dictionary<string, object> query = null)
        {
            return await SendRequest<T>(HttpMethod.Get, path, query);
        }

        internal async Task<T> Post<T>(string path, object body)
        {
            return await SendRequest<T>(HttpMethod.Post, path, null, body);
        }

        internal async Task<T> Post<T>(string path, Dictionary<string, object> query, object body)
        {
            return await SendRequest<T>(HttpMethod.Post, path, query, body);
        }

        internal async Task Post(string path, object body)
        {
            await SendRequest(HttpMethod.Post, path, null, body);
        }

        internal async Task Post(string path, Dictionary<string, object> query, object body)
        {
            await SendRequest(HttpMethod.Post, path, query, body);
        }

        private async Task<T> SendRequest<T>(HttpMethod method, string path,
            Dictionary<string, object> query = null, object body = null)
        {
            var responseJson = await SendRequest(method, path, query, body);
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        private async Task<string> SendRequest(HttpMethod method, string path,
            Dictionary<string, object> query = null, object body = null)
        {
            var queryString = string.Empty;
            if (query != null)
            {
                queryString = query.ToQueryString();
            }

            using (var message = new HttpRequestMessage(method, path + queryString))
            {
                string bodyJson = null;
                if (body != null)
                {
                    bodyJson = JsonConvert.SerializeObject(body);
                    message.Content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                }
                var timestamp = DateTimeOffset.UtcNow.ToUnixTime().ToString();
                var hash = SignWithHmacsha256(timestamp + method + path + queryString + bodyJson);
                message.Headers.Add("ACCESS-KEY", _apiKey);
                message.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                message.Headers.Add("ACCESS-SIGN", hash);

                try
                {
                    var response = await HttpClient.SendAsync(message);
                    var responseJson = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = JsonConvert.DeserializeObject<Error>(responseJson);
                        if (!string.IsNullOrEmpty(error?.ErrorMessage))
                        {
                            throw new BitFlyerApiException(path, error.ErrorMessage, error);
                        }
                        throw new BitFlyerApiException(path,
                            $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                    }

                    return responseJson;
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
