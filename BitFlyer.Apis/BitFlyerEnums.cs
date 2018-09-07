using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public enum CurrencyCode
    {
        [EnumMember(Value = "JPY")]
        Jpy,

        [EnumMember(Value = "BTC")]
        Btc,

        [EnumMember(Value = "ETH")]
        Eth,

        [EnumMember(Value = "ETC")]
        Etc,

        [EnumMember(Value = "LTC")]
        Ltc,

        [EnumMember(Value = "BCH")]
        Bch,

        [EnumMember(Value = "MONA")]
        Mona,

        [EnumMember(Value = "LSK")]
        Lisk,

        Unknown
    }

    public enum Side
    {
        [EnumMember(Value = "")]
        Unknown,

        [EnumMember(Value = "BUY")]
        Buy,

        [EnumMember(Value = "SELL")]
        Sell,

        [EnumMember(Value = "BUYSELL")]
        BuySell
    }

    public enum BitflyerSystemHealth
    {
        [EnumMember(Value = "NORMAL")]
        Normal,

        [EnumMember(Value = "BUSY")]
        Busy,

        [EnumMember(Value = "VERY BUSY")]
        VeryBusy,

        [EnumMember(Value = "SUPER BUSY")]
        SuperBusy,

        [EnumMember(Value = "NO ORDER")]
        NoOrder,

        [EnumMember(Value = "STOP")]
        Stop
    }

    public enum BoardStates
    {
        [EnumMember(Value = "RUNNING")]
        Running,

        [EnumMember(Value = "CLOSED")]
        Closed,

        [EnumMember(Value = "STARTING")]
        Starting,

        [EnumMember(Value = "PREOPEN")]
        Preopen,

        [EnumMember(Value = "CIRCUIT BREAK")]
        CircuitBreak,

        [EnumMember(Value = "AWAITING SQ")]
        AWAITING_SQ,

        [EnumMember(Value = "MATURED")]
        MATURED,
    }

    public enum DepositStatus
    {
        [EnumMember(Value = "PENDING")]
        Pending,

        [EnumMember(Value = "COMPLETED")]
        Completed
    }

    public enum ChildOrderType
    {
        [EnumMember(Value = "LIMIT")]
        Limit,

        [EnumMember(Value = "MARKET")]
        Market
    }

    public enum TimeInForce
    {
        [EnumMember(Value = "GTC")]
        GoodTilCanceled,

        [EnumMember(Value = "IOC")]
        ImmediateOrCancel,

        [EnumMember(Value = "FOK")]
        FillOrKill
    }

    public enum OrderMethod
    {
        [EnumMember(Value = "SIMPLE")]
        Simple,

        [EnumMember(Value = "IFD")]
        IfDone,

        [EnumMember(Value = "OCO")]
        OneCancelsTheOther,

        [EnumMember(Value = "IFDOCO")]
        IfDoneOneCancelsTheOther
    }

    public enum ParentOrderType
    {
        [EnumMember(Value = "IFD")]
        IfDone,

        [EnumMember(Value = "OCO")]
        OneCancelsTheOther,

        [EnumMember(Value = "IFDOCO")]
        IfDoneOneCancelsTheOther,

        [EnumMember(Value = "STOP")]
        Stop,

        [EnumMember(Value = "STOP_LIMIT")]
        StopLimit,

        [EnumMember(Value = "TRAIL")]
        Trail,
    }

    public enum ConditionType
    {
        [EnumMember(Value = "LIMIT")]
        Limit,

        [EnumMember(Value = "MARKET")]
        Market,

        [EnumMember(Value = "STOP")]
        Stop,

        [EnumMember(Value = "STOP_LIMIT")]
        StopLimit,

        [EnumMember(Value = "TRAIL")]
        Trail
    }

    public enum AddresseType
    {
        [EnumMember(Value = "NORMAL")]
        Normal
    }

    public enum ChildOrderState
    {
        [EnumMember(Value = "ACTIVE")]
        Active,

        [EnumMember(Value = "COMPLETED")]
        Completed,

        [EnumMember(Value = "CANCELED")]
        Canceled,

        [EnumMember(Value = "EXPIRED")]
        Expired,

        [EnumMember(Value = "REJECTED")]
        Rejected
    }

    public enum ParentOrderState
    {
        [EnumMember(Value = "ACTIVE")]
        Active,

        [EnumMember(Value = "COMPLETED")]
        Completed,

        [EnumMember(Value = "CANCELED")]
        Canceled,

        [EnumMember(Value = "EXPIRED")]
        Expired,

        [EnumMember(Value = "REJECTED")]
        Rejected
    }

    public enum ProductAlias
    {
        [EnumMember(Value = "")]
        None,

        [EnumMember(Value = "BTCJPY_MAT1WK")]
        BtcJpyThisWeek,

        [EnumMember(Value = "BTCJPY_MAT2WK")]
        BtcJpyNextWeek,

        [EnumMember(Value = "BTCJPY_MAT3M")]
        BtcJpyWeekAfterNext,
    }

    public enum CollateralReasonCode
    {
        [EnumMember(Value = "CLEARING_COLL")]
        Clearing,

        [EnumMember(Value = "EXCHANGE_COLL")]
        Exchange,

        [EnumMember(Value = "POST_COLL")]
        Post,

        [EnumMember(Value = "CANCEL_COLL")]
        Cancel
    }
}
