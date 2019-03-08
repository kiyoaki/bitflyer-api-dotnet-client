using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string BalanceHistoryApiPath = "/v1/me/getbalancehistory";

        public async Task<BalanceHistory[]> GetBalanceHistory(CurrencyCode currencyCode, int? count = null, int? before = null, int? after = null,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object>()
            {
                { "currency_code", currencyCode.GetEnumMemberValue() }
            };

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

            return await Get<BalanceHistory[]>(BalanceHistoryApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
