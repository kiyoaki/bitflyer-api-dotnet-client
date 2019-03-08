using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string ChatEuApiPath = "/v1/getchats/eu";

        public static async Task<Chat[]> GetChatEu(DateTime? fromDate = null, CancellationToken cancellationToken = default)
        {
            if (fromDate != null)
            {
                var query = new Dictionary<string, object>
                {
                    { "from_date", fromDate.Value }
                };

                return await Get<Chat[]>(ChatEuApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
            }

            return await Get<Chat[]>(ChatEuApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
