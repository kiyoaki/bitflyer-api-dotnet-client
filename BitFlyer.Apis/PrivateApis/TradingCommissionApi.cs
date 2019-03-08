using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetTradingCommissionApiPath = "/v1/me/gettradingcommission";

        public async Task<TradingCommission> GetTradingCommission(string productCode, CancellationToken cancellationToken = default)
        {
            return await Get<TradingCommission>(GetTradingCommissionApiPath, new Dictionary<string, object>
            {
                { "product_code", productCode }
            }, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
