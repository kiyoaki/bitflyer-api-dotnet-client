using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis
{
    [JsonConverter(typeof(StringEnumConverter))]
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

        Unknown
    }

    [JsonConverter(typeof(StringEnumConverter))]
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

    [JsonConverter(typeof(StringEnumConverter))]
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

        [EnumMember(Value = "STOP")]
        Stop
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum DepositStatus
    {
        [EnumMember(Value = "PENDING")]
        Pending,

        [EnumMember(Value = "COMPLETED")]
        Completed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ChildOrderType
    {
        [EnumMember(Value = "LIMIT")]
        Limit,

        [EnumMember(Value = "MARKET")]
        Market
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum TimeInForce
    {
        [EnumMember(Value = "GTC")]
        GoodTilCanceled,

        [EnumMember(Value = "IOC")]
        ImmediateOrCancel,

        [EnumMember(Value = "FOK")]
        FillOrKill
    }

    [JsonConverter(typeof(StringEnumConverter))]
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

    [JsonConverter(typeof(StringEnumConverter))]
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

    [JsonConverter(typeof(StringEnumConverter))]
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddresseType
    {
        [EnumMember(Value = "NORMAL")]
        Normal
    }

    [JsonConverter(typeof(StringEnumConverter))]
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

    [JsonConverter(typeof(StringEnumConverter))]
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

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductAlias
    {
        [EnumMember(Value = "")]
        None,

        [EnumMember(Value = "BTCJPY_MAT1WK")]
        BtcJpyThisWeek,

        [EnumMember(Value = "BTCJPY_MAT2WK")]
        BtcJpyNextWeek
    }
}
