using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPublicApiClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private static volatile BitFlyerPublicApiClient _instance;
        private static readonly object SyncRoot = new object();

        private BitFlyerPublicApiClient(TimeSpan? timeout)
        {
            HttpClient.BaseAddress = BitFlyerConstants.BaseUri;
            HttpClient.Timeout = timeout ?? TimeSpan.FromSeconds(10);
        }

        public static BitFlyerPublicApiClient GetInstance(TimeSpan? timeout = null)
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new BitFlyerPublicApiClient(timeout);
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

        private static async Task<T> SendRequest<T>(HttpMethod method, string path, 
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
    }
}
