using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public static class RealtimeChannel
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

        #region EthJpy
        public const string BoardSnapshotEthJpy = BoardSnapshotPrefix + ProductCode.EthJpy;
        public const string BoardEthJpy = BoardPrefix + ProductCode.EthJpy;
        public const string TickerEthJpy = TickerPrefix + ProductCode.EthJpy;
        public const string ExecutionsEthJpy = ExecutionPrefix + ProductCode.EthJpy;
        #endregion

        #region BchBtc
        public const string BoardSnapshotBchBtc = BoardSnapshotPrefix + ProductCode.BchBtc;
        public const string BoardBchBtc = BoardPrefix + ProductCode.BchBtc;
        public const string TickerBchBtc = TickerPrefix + ProductCode.BchBtc;
        public const string ExecutionsBchBtc = ExecutionPrefix + ProductCode.BchBtc;
        #endregion

        #region BchJpy
        public const string BoardSnapshotBchJpy = BoardSnapshotPrefix + ProductCode.BchJpy;
        public const string BoardBchJpy = BoardPrefix + ProductCode.BchJpy;
        public const string TickerBchJpy = TickerPrefix + ProductCode.BchJpy;
        public const string ExecutionsBchJpy = ExecutionPrefix + ProductCode.BchJpy;
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

        #region MonaJpy
        public const string BoardSnapshotMonaJpy = BoardSnapshotPrefix + ProductCode.MonaJpy;
        public const string BoardMonaJpy = BoardPrefix + ProductCode.MonaJpy;
        public const string TickerMonaJpy = TickerPrefix + ProductCode.MonaJpy;
        public const string ExecutionsMonaJpy = ExecutionPrefix + ProductCode.MonaJpy;
        #endregion

        #region MonaBtc
        public const string BoardSnapshotMonaBtc = BoardSnapshotPrefix + ProductCode.MonaBtc;
        public const string BoardMonaBtc = BoardPrefix + ProductCode.MonaBtc;
        public const string TickerMonaBtc = TickerPrefix + ProductCode.MonaBtc;
        public const string ExecutionsMonaBtc = ExecutionPrefix + ProductCode.MonaBtc;
        #endregion

        #region LtcBtc
        public const string BoardSnapshotLtcBtc = BoardSnapshotPrefix + ProductCode.LtcBtc;
        public const string BoardLtcBtc = BoardPrefix + ProductCode.LtcBtc;
        public const string TickerLtcBtc = TickerPrefix + ProductCode.LtcBtc;
        public const string ExecutionsLtcBtc = ExecutionPrefix + ProductCode.LtcBtc;
        #endregion

        #region XrpJpy
        public const string BoardSnapshotXrpJpy = BoardSnapshotPrefix + ProductCode.XrpJpy;
        public const string BoardXrpJpy = BoardPrefix + ProductCode.XrpJpy;
        public const string TickerXrpJpy = TickerPrefix + ProductCode.XrpJpy;
        public const string ExecutionsXrpJpy = ExecutionPrefix + ProductCode.XrpJpy;
        #endregion

        #region XrpBtc
        public const string BoardSnapshotXrpBtc = BoardSnapshotPrefix + ProductCode.XrpBtc;
        public const string BoardXrpBtc = BoardPrefix + ProductCode.XrpBtc;
        public const string TickerXrpBtc = TickerPrefix + ProductCode.XrpBtc;
        public const string ExecutionsXrpBtc = ExecutionPrefix + ProductCode.XrpBtc;
        #endregion

        #region XlmJpy
        public const string BoardSnapshotXlmJpy = BoardSnapshotPrefix + ProductCode.XlmJpy;
        public const string BoardXlmJpy = BoardPrefix + ProductCode.XlmJpy;
        public const string TickerXlmJpy = TickerPrefix + ProductCode.XlmJpy;
        public const string ExecutionsXlmJpy = ExecutionPrefix + ProductCode.XlmJpy;
        #endregion

        #region XlmBtc
        public const string BoardSnapshotXlmBtc = BoardSnapshotPrefix + ProductCode.XlmBtc;
        public const string BoardXlmBtc = BoardPrefix + ProductCode.XlmBtc;
        public const string TickerXlmBtc = TickerPrefix + ProductCode.XlmBtc;
        public const string ExecutionsXlmBtc = ExecutionPrefix + ProductCode.XlmBtc;
        #endregion

        #region XemJpy
        public const string BoardSnapshotXemJpy = BoardSnapshotPrefix + ProductCode.XemJpy;
        public const string BoardXemJpy = BoardPrefix + ProductCode.XemJpy;
        public const string TickerXemJpy = TickerPrefix + ProductCode.XemJpy;
        public const string ExecutionsXemJpy = ExecutionPrefix + ProductCode.XemJpy;
        #endregion

        #region XemBtc
        public const string BoardSnapshotXemBtc = BoardSnapshotPrefix + ProductCode.XemBtc;
        public const string BoardXemBtc = BoardPrefix + ProductCode.XemBtc;
        public const string TickerXemBtc = TickerPrefix + ProductCode.XemBtc;
        public const string ExecutionsXemBtc = ExecutionPrefix + ProductCode.XemBtc;
        #endregion

        #region BatJpy
        public const string BoardSnapshotBatJpy = BoardSnapshotPrefix + ProductCode.BatJpy;
        public const string BoardBatJpy = BoardPrefix + ProductCode.BatJpy;
        public const string TickerBatJpy = TickerPrefix + ProductCode.BatJpy;
        public const string ExecutionsBatJpy = ExecutionPrefix + ProductCode.BatJpy;
        #endregion

        #region BatBtc
        public const string BoardSnapshotBatBtc = BoardSnapshotPrefix + ProductCode.BatBtc;
        public const string BoardBatBtc = BoardPrefix + ProductCode.BatBtc;
        public const string TickerBatBtc = TickerPrefix + ProductCode.BatBtc;
        public const string ExecutionsBatBtc = ExecutionPrefix + ProductCode.BatBtc;
        #endregion

        #region OmgJpy
        public const string BoardSnapshotOmgJpy = BoardSnapshotPrefix + ProductCode.OmgJpy;
        public const string BoardOmgJpy = BoardPrefix + ProductCode.OmgJpy;
        public const string TickerOmgJpy = TickerPrefix + ProductCode.OmgJpy;
        public const string ExecutionsOmgJpy = ExecutionPrefix + ProductCode.OmgJpy;
        #endregion

        #region OmgBtc
        public const string BoardSnapshotOmgBtc = BoardSnapshotPrefix + ProductCode.OmgBtc;
        public const string BoardOmgBtc = BoardPrefix + ProductCode.OmgBtc;
        public const string TickerOmgBtc = TickerPrefix + ProductCode.OmgBtc;
        public const string ExecutionsOmgBtc = ExecutionPrefix + ProductCode.OmgBtc;
        #endregion

        #region BtcJpyThisWeek
        public static async Task<string> GetBoardSnapshotBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return BoardSnapshotPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetBoardBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return BoardPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetTickerBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return TickerPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetExecutionBtcJpyThisWeek()
        {
            var productCode = await ProductCode.GetBtcJpyThisWeek().ConfigureAwait(false);
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
            var productCode = await ProductCode.GetBtcJpyNextWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return BoardSnapshotPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetBoardBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return BoardPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetTickerBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return TickerPrefix + productCode;
            }
            return null;
        }

        public static async Task<string> GetExecutionBtcJpyNextWeek()
        {
            var productCode = await ProductCode.GetBtcJpyNextWeek().ConfigureAwait(false);
            if (productCode != null)
            {
                return ExecutionPrefix + productCode;
            }
            return null;
        }
        #endregion BtcJpyNextWeek
    }
}
