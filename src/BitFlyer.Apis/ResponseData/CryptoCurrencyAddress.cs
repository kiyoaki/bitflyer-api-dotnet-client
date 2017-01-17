using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class CryptoCurrencyAddress
    {
        [JsonProperty("type")]
        public AddresseType Type { get; set; }

        [JsonProperty("currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
