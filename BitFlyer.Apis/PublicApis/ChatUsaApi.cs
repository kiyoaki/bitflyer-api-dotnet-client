using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string ChatUsaApiPath = "/v1/getchats/usa";

        public static async Task<Chat[]> GetChatUsa(DateTime? fromDate = null, CancellationToken cancellationToken = default)
        {
            if (fromDate != null)
            {
                var query = new Dictionary<string, object>
                {
                    { "from_date", fromDate.Value }
                };

                return await Get<Chat[]>(ChatUsaApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
            }

            return await Get<Chat[]>(ChatUsaApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
