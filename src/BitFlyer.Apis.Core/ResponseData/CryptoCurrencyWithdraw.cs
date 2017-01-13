using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis.Core.ResponseData
{
    public struct CryptoCurrencyWithdraw
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("tx_hash")]
        public string TransactionHash { get; set; }

        [JsonProperty("additional_fee")]
        public double AdditionalFee { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DepositStatus Status { get; set; }

        [JsonProperty("event_date")]
        public DateTime EventDate { get; set; }

    }
}
