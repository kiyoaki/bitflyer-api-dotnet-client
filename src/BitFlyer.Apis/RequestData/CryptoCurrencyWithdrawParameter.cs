using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis
{
    public class CryptoCurrencyWithdrawParameter
    {
        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("additional_fee")]
        public double AdditionalFee { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
