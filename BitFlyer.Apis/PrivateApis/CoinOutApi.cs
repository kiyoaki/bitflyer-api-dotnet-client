using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string CoinOutApiPath = "/v1/me/getcoinouts";

        public async Task<CoinOut> GetCoinOut(string messageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            var query = new Dictionary<string, object>
            {
                { "message_id", messageId }
            };

            return await Get<CoinOut>(CoinOutApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<CoinOut[]> GetCoinOuts(int? count = null, int? before = null, int? after = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = new Dictionary<string, object>();

            if (count != null)
            {
                query["count"] = count.Value;
            }
            if (before != null)
            {
                query["before"] = before.Value;
            }
            if (after != null)
            {
                query["after"] = after.Value;
            }

            return await Get<CoinOut[]>(CoinOutApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
