
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis.Core.ResponseData
{
    public struct CurrencyDeposit
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DepositStatus Status { get; set; }

        [JsonProperty("event_date")]
        public DateTime EventDate { get; set; }

    }
}
