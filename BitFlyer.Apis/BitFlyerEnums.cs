using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BitFlyer.Apis.JsonConverters;

namespace BitFlyer.Apis;

[JsonConverter(typeof(EnumMemberConverter))]
public enum CurrencyCode
{
    [EnumMember(Value = "")]
    Unknown,

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
    Lsk,

    [EnumMember(Value = "BAT")]
    Bat,

    [EnumMember(Value = "XRP")]
    Xrp,

    [EnumMember(Value = "XYM")]
    Xym,

    [EnumMember(Value = "LINK")]
    Link,

    [EnumMember(Value = "DOT")]
    Dot,

    [EnumMember(Value = "XTZ")]
    Xtz,

    [EnumMember(Value = "XLM")]
    Xlm,

    [EnumMember(Value = "XEM")]
    Xem,

    [EnumMember(Value = "USD")]
    Usd,

    [EnumMember(Value = "EUR")]
    Eur,

    [EnumMember(Value = "SHIB")]
    Shib,

    [EnumMember(Value = "PLT")]
    Plt,

    [EnumMember(Value = "FLR")]
    Flr,

    [EnumMember(Value = "MATIC")]
    Matic,

    [EnumMember(Value = "MKR")]
    Mkr,

    [EnumMember(Value = "ZPG")]
    Zpg,

    [EnumMember(Value = "SAND")]
    Sand,
}

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
public enum DepositStatus
{
    [EnumMember(Value = "PENDING")]
    Pending,

    [EnumMember(Value = "COMPLETED")]
    Completed
}

[JsonConverter(typeof(EnumMemberConverter))]
public enum ChildOrderType
{
    [EnumMember(Value = "LIMIT")]
    Limit,

    [EnumMember(Value = "MARKET")]
    Market
}

[JsonConverter(typeof(EnumMemberConverter))]
public enum TimeInForce
{
    [EnumMember(Value = "GTC")]
    GoodTilCanceled,

    [EnumMember(Value = "IOC")]
    ImmediateOrCancel,

    [EnumMember(Value = "FOK")]
    FillOrKill
}

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
public enum AddresseType
{
    [EnumMember(Value = "NORMAL")]
    Normal
}

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
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

[JsonConverter(typeof(EnumMemberConverter))]
public enum TradeType
{
    [EnumMember(Value = "")]
    Unknown,

    [EnumMember(Value = "BUY")]
    Buy,

    [EnumMember(Value = "SELL")]
    Sell,

    [EnumMember(Value = "DEPOSIT")]
    Deposit,

    [EnumMember(Value = "WITHDRAW")]
    Withdraw,

    [EnumMember(Value = "FEE")]
    Fee,

    [EnumMember(Value = "POST_COLL")]
    Post,

    [EnumMember(Value = "CANCEL_COLL")]
    Cancel,

    [EnumMember(Value = "PAYMENT")]
    Payment,

    [EnumMember(Value = "TRANSFER")]
    Transfer
}
