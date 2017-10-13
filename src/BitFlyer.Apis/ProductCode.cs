using System.Linq;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public static class ProductCode
    {
        public const string BtcJpy = "BTC_JPY";
        public const string FxBtcJpy = "FX_BTC_JPY";
        public const string EthBtc = "ETH_BTC";
        public const string BchBtc = "BCH_BTC";
        public const string BtcUsd = "BTC_USD";

        public static async Task<string> GetBtcJpyThisWeek()
        {
            var markets = await PublicApi.GetMarkets();
            var btcJpyThisWeekMarket = markets.FirstOrDefault(x => x.ProductAlias == ProductAlias.BtcJpyThisWeek);
            return btcJpyThisWeekMarket?.ProductCode;
        }
    }
}
