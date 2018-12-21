using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Utf8Json;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = BitFlyerConstants.BaseUri,
            Timeout = TimeSpan.FromSeconds(60)
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
                var response = await HttpClient.GetAsync(path + queryString).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    Error error = null;
                    try
                    {
                        error = JsonSerializer.Deserialize<Error>(json);
                    }
                    catch
                    {
                        // ignore
                    }

                    if (!string.IsNullOrEmpty(error?.ErrorMessage))
                    {
                        throw new BitFlyerApiException(path, error.ErrorMessage, error);
                    }
                    throw new BitFlyerApiException(path,
                        $"Error has occurred. Response StatusCode:{response.StatusCode} ReasonPhrase:{response.ReasonPhrase}.");
                }

                return JsonSerializer.Deserialize<T>(json);
            }
            catch (WebException ex)
            {
                switch (ex.Status)
                {
                    case WebExceptionStatus.RequestCanceled:
                    case WebExceptionStatus.Timeout:
                        throw new BitFlyerApiException(path, "Request Timeout");
                    default:
                        throw;
                }
            }
            catch (TaskCanceledException)
            {
                throw new BitFlyerApiException(path, "Request Timeout");
            }
            catch (OperationCanceledException)
            {
                throw new BitFlyerApiException(path, "Request Timeout");
            }
        }
    }
}
