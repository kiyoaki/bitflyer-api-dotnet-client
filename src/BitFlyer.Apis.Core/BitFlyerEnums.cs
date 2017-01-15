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
        Eth
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Side
    {
        [EnumMember(Value = "BUY")]
        Buy,

        [EnumMember(Value = "SELL")]
        Sell
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductCode
    {
        [EnumMember(Value = "BTC_JPY")]
        BtcJpy,

        [EnumMember(Value = "FX_BTC_JPY")]
        FxBtcJpy,

        [EnumMember(Value = "ETH_BTC")]
        EthBtc
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
        Gtc,

        [EnumMember(Value = "IOC")]
        Ioc,

        [EnumMember(Value = "FOK")]
        Fok
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
        Trail,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AddresseType
    {
        [EnumMember(Value = "NORMAL")]
        Normal
    }
}
