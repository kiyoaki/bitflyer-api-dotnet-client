using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public static class PubnubChannel
    {
        public const string BoardSnapshotBtcJpy = "lightning_board_snapshot_BTC_JPY";

        public const string BoardSnapshotFxBtcJpy = "lightning_board_snapshot_FX_BTC_JPY";

        public const string BoardSnapshotEthBtc = "lightning_board_snapshot_ETH_BTC";

        public const string BoardBtcJpy = "lightning_board_BTC_JPY";

        public const string BoardFxBtcJpy = "lightning_board_FX_BTC_JPY";

        public const string BoardEthBtc = "lightning_board_ETH_BTC";

        public const string TickerBtcJpy = "lightning_ticker_BTC_JPY";

        public const string TickerFxBtcJpy = "lightning_ticker_FX_BTC_JPY";

        public const string TickerEthBtc = "lightning_ticker_ETH_BTC";

        public const string ExecutionsBtcJpy = "lightning_executions_BTC_JPY";

        public const string ExecutionsFxBtcJpy = "lightning_executions_FX_BTC_JPY";

        public const string ExecutionsEthBtc = "lightning_executions_ETH_BTC";

        public static async Task<string> GetBoardSnapshotBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return BoardSnapshot + productCode;
            }
            return null;
        }

        public static async Task<string> GetBoardBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return Board + productCode;
            }
            return null;
        }

        public static async Task<string> GeTickerBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return Ticker + productCode;
            }
            return null;
        }

        public static async Task<string> GeExecutionBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return Execution + productCode;
            }
            return null;
        }

        private const string BoardSnapshot = "lightning_board_snapshot_";

        private const string Board = "lightning_board_";

        private const string Ticker = "lightning_ticker_";

        private const string Execution = "lightning_executions_";
    }
}
