using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetTradingCommissionApiPath = "/v1/me/gettradingcommission";

        public async Task<TradingCommission> GetTradingCommission(string productCode)
        {
            return await Get<TradingCommission>(GetTradingCommissionApiPath, new Dictionary<string, object>
            {
                { "product_code", productCode }
            });
        }
    }
}
