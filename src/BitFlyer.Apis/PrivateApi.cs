using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private static readonly MediaTypeHeaderValue MediaType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
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
            return JsonSerializer.Deserialize<T>(responseJson);
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
                byte[] bodyBytes = null;
                if (body != null)
                {
                    bodyBytes = JsonSerializer.Serialize(body);
                    message.Content = new ByteArrayContent(bodyBytes);
                    message.Content.Headers.ContentType = MediaType;
                }
                var timestamp = DateTimeOffset.UtcNow.ToUnixTime().ToString();
                var payload = bodyBytes == null ? Encoding.UTF8.GetBytes(timestamp + method + path + queryString) :
                    Encoding.UTF8.GetBytes(timestamp + method + path + queryString).Concat(bodyBytes).ToArray();
                var hash = SignWithHmacsha256(payload);
                message.Headers.Add("ACCESS-KEY", _apiKey);
                message.Headers.Add("ACCESS-TIMESTAMP", timestamp);
                message.Headers.Add("ACCESS-SIGN", hash);

                try
                {
                    var response = await HttpClient.SendAsync(message);
                    var responseJson = await response.Content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = JsonSerializer.Deserialize<Error>(responseJson);
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

        private string SignWithHmacsha256(byte[] utf8Bytes)
        {
            using (var encoder = new HMACSHA256(_apiSecret))
            {
                var hash = encoder.ComputeHash(utf8Bytes);
                return FastHexString.ToHex(hash);
            }
        }
    }
}
