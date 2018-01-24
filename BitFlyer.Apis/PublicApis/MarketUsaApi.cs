using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string MarketUsaApiPath = "/v1/markets/usa";

        public static async Task<Market[]> GetMarketsUsa()
        {
            return await Get<Market[]>(MarketUsaApiPath);
        }
    }
}
