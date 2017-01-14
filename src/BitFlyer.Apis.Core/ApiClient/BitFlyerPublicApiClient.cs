using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public class BitFlyerPublicApiClient
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

        public async Task<string> Get(string path, string query)
        {
            return await SendRequest(HttpMethod.Get, path, query);
        }

        public async Task<string> Post(string path, string query, string body)
        {
            return await SendRequest(HttpMethod.Post, path, query, body);
        }

        private static async Task<string> SendRequest(HttpMethod httpMethod, string path, string query, string json = "")
        {
            using (var message = new HttpRequestMessage(httpMethod, path + query)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            })
            {
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
    }
}
