using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string MarketApiPath = "/v1/markets";

        public static async Task<Market[]> GetMarkets()
        {
            return await Get<Market[]>(MarketApiPath);
        }
    }
}
