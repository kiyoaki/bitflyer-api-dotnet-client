using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public static class PubnubChannel
    {
        #region prefix
        public const string BoardSnapshotPrefix = "lightning_board_snapshot_";
        public const string BoardPrefix = "lightning_board_";
        public const string TickerPrefix = "lightning_ticker_";
        public const string ExecutionPrefix = "lightning_executions_";
        #endregion

        #region BtcJpy
        public const string BoardSnapshotBtcJpy = BoardSnapshotPrefix + ProductCode.BtcJpy;
        public const string BoardBtcJpy = BoardPrefix + ProductCode.BtcJpy;
        public const string TickerBtcJpy = TickerPrefix + ProductCode.BtcJpy;
        public const string ExecutionsBtcJpy = ExecutionPrefix + ProductCode.BtcJpy;
        #endregion

        #region FxBtcJpy
        public const string BoardSnapshotFxBtcJpy = BoardSnapshotPrefix + ProductCode.FxBtcJpy;
        public const string BoardFxBtcJpy = BoardPrefix + ProductCode.FxBtcJpy;
        public const string TickerFxBtcJpy = TickerPrefix + ProductCode.FxBtcJpy;
        public const string ExecutionsFxBtcJpy = ExecutionPrefix + ProductCode.FxBtcJpy;
        #endregion

        #region EthBtc
        public const string BoardSnapshotEthBtc = BoardSnapshotPrefix + ProductCode.EthBtc;
        public const string BoardEthBtc = BoardPrefix + ProductCode.EthBtc;
        public const string TickerEthBtc = TickerPrefix + ProductCode.EthBtc;
        public const string ExecutionsEthBtc = ExecutionPrefix + ProductCode.EthBtc;
        #endregion

        #region BchBtc
        public const string BoardSnapshotBchBtc = BoardSnapshotPrefix + ProductCode.BchBtc;
        public const string BoardBchBtc = BoardPrefix + ProductCode.BchBtc;
        public const string TickerBchBtc = TickerPrefix + ProductCode.BchBtc;
        public const string ExecutionsBchBtc = ExecutionPrefix + ProductCode.BchBtc;
        #endregion

        #region BtcUsd
        public const string BoardSnapshotBtcUsd = BoardSnapshotPrefix + ProductCode.BtcUsd;
        public const string BoardBtcUsd = BoardPrefix + ProductCode.BtcUsd;
        public const string TickerBtcUsd = TickerPrefix + ProductCode.BtcUsd;
        public const string ExecutionsBtcUsd = ExecutionPrefix + ProductCode.BtcUsd;
        #endregion

        #region BtcEur
        public const string BoardSnapshotBtcEur = BoardSnapshotPrefix + ProductCode.BtcEur;
        public const string BoardBtcEur = BoardPrefix + ProductCode.BtcEur;
        public const string TickerBtcEur = TickerPrefix + ProductCode.BtcEur;
        public const string ExecutionsBtcEur = ExecutionPrefix + ProductCode.BtcEur;
        #endregion

        #region BtcJpyThisWeek
        public static async Task<string> GetBoardSnapshotBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return BoardSnapshotPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetBoardBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return BoardPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetTickerBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return TickerPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetExecutionBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek();
            if (productCode != null)
            {
                return ExecutionPrefix + productCode;
            }
            return null;
        }
        #endregion BtcJpyThisWeek

        #region BtcJpyNextWeek
        public static async Task<string> GetBoardSnapshotBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek();
            if (productCode != null)
            {
                return BoardSnapshotPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetBoardBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek();
            if (productCode != null)
            {
                return BoardPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetTickerBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek();
            if (productCode != null)
            {
                return TickerPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetExecutionBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek();
            if (productCode != null)
            {
                return ExecutionPrefix + productCode;
            }
            return null;
        }
        #endregion BtcJpyNextWeek
    }
}
