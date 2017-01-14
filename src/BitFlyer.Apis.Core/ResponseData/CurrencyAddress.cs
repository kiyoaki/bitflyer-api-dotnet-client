using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis
{
    public struct CurrencyAddress
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
