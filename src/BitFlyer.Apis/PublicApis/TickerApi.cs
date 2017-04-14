using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string TickerApiPath = "/v1/ticker";

        public static async Task<Ticker> GetTicker(string productCode)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode }
            };
            return await Get<Ticker>(TickerApiPath, query);
        }
    }
}
