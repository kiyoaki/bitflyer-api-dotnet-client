using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public static class ProductCode
    {
        public const string BtcJpy = "BTC_JPY";
        public const string FxBtcJpy = "FX_BTC_JPY";
        public const string EthBtc = "ETH_BTC";
        public const string EthJpy = "ETH_JPY";
        public const string BchBtc = "BCH_BTC";
        public const string BchJpy = "BCH_JPY";
        public const string BtcUsd = "BTC_USD";
        public const string BtcEur = "BTC_EUR";
        public const string MonaJpy = "MONA_JPY";
        public const string MonaBtc = "MONA_BTC";
        public const string LtcBtc = "LTC_BTC";
        public const string XrpJpy = "XRP_JPY";
        public const string XrpBtc = "XRP_BTC";
        public const string XlmJpy = "XLM_JPY";
        public const string XlmBtc = "XLM_BTC";
        public const string XemJpy = "XEM_JPY";
        public const string XemBtc = "XEM_BTC";
        public const string BatJpy = "BAT_JPY";
        public const string BatBtc = "BAT_BTC";
        public const string OmgJpy = "OMG_JPY";
        public const string OmgBtc = "OMG_BTC";

        public static IReadOnlyList<string> All { get; } = new[]
        {
            BtcJpy,
            FxBtcJpy,
            EthBtc,
            EthJpy,
            BchBtc,
            BchJpy,
            BtcUsd,
            BtcEur,
            MonaJpy,
            MonaBtc,
            LtcBtc,
            XrpJpy,
            XrpBtc,
            XlmJpy,
            XlmBtc,
            XemJpy,
            XemBtc,
            BatJpy,
            BatBtc,
            OmgJpy,
            OmgBtc,
        };

        public static async Task<string> GetBtcJpyThisWeek()
        {
            var markets = await PublicApi.GetMarkets().ConfigureAwait(false);
            var btcJpyThisWeekMarket = markets.FirstOrDefault(x => x.ProductAlias == ProductAlias.BtcJpyThisWeek);
            return btcJpyThisWeekMarket?.ProductCode;
        }

        public static async Task<string> GetBtcJpyNextWeek()
        {
            var markets = await PublicApi.GetMarkets().ConfigureAwait(false);
            var btcJpyNextWeekMarket = markets.FirstOrDefault(x => x.ProductAlias == ProductAlias.BtcJpyNextWeek);
            return btcJpyNextWeekMarket?.ProductCode;
        }
    }
}
