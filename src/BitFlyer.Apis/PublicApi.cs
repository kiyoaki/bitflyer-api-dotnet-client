using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = BitFlyerConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(10)
        };

        internal static async Task<T> Get<T>(string path, Dictionary<string, object> query = null)
        {
            var queryString = string.Empty;
            if (query != null)
            {
                queryString = query.ToQueryString();
            }

            try
            {
                var response = await HttpClient.GetAsync(path + queryString);
                var json = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
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
