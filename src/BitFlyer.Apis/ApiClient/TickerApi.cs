using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPublicApiClient
    {
        private const string TickerApiPath = "/v1/ticker";

        public async Task<Ticker> GetTicker(ProductCode productCode)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode.GetEnumMemberValue() }
            };
            return await Get<Ticker>(TickerApiPath, query);
        }
    }
}
