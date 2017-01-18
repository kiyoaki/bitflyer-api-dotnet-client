using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class SendCoinParameter
    {
        [JsonProperty("currency_code")]
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
