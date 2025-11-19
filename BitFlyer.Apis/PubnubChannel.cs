using System.Threading.Tasks;

namespace BitFlyer.Apis;

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

    #region XrpJpy
    public const string BoardSnapshotXrpJpy = BoardSnapshotPrefix + ProductCode.XrpJpy;
    public const string BoardXrpJpy = BoardPrefix + ProductCode.XrpJpy;
    public const string TickerXrpJpy = TickerPrefix + ProductCode.XrpJpy;
    public const string ExecutionsXrpJpy = ExecutionPrefix + ProductCode.XrpJpy;
    #endregion

    #region EthJpy
    public const string BoardSnapshotEthJpy = BoardSnapshotPrefix + ProductCode.EthJpy;
    public const string BoardEthJpy = BoardPrefix + ProductCode.EthJpy;
    public const string TickerEthJpy = TickerPrefix + ProductCode.EthJpy;
    public const string ExecutionsEthJpy = ExecutionPrefix + ProductCode.EthJpy;
    #endregion

    #region XlmJpy
    public const string BoardSnapshotXlmJpy = BoardSnapshotPrefix + ProductCode.XlmJpy;
    public const string BoardXlmJpy = BoardPrefix + ProductCode.XlmJpy;
    public const string TickerXlmJpy = TickerPrefix + ProductCode.XlmJpy;
    public const string ExecutionsXlmJpy = ExecutionPrefix + ProductCode.XlmJpy;
    #endregion

    #region MonaJpy
    public const string BoardSnapshotMonaJpy = BoardSnapshotPrefix + ProductCode.MonaJpy;
    public const string BoardMonaJpy = BoardPrefix + ProductCode.MonaJpy;
    public const string TickerMonaJpy = TickerPrefix + ProductCode.MonaJpy;
    public const string ExecutionsMonaJpy = ExecutionPrefix + ProductCode.MonaJpy;
    #endregion

    #region ElfJpy
    public const string BoardSnapshotElfJpy = BoardSnapshotPrefix + ProductCode.ElfJpy;
    public const string BoardElfJpy = BoardPrefix + ProductCode.ElfJpy;
    public const string TickerElfJpy = TickerPrefix + ProductCode.ElfJpy;
    public const string ExecutionsElfJpy = ExecutionPrefix + ProductCode.ElfJpy;
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
}
