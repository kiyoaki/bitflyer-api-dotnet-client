using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Market
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("alias")]
        public ProductAlias ProductAlias { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
