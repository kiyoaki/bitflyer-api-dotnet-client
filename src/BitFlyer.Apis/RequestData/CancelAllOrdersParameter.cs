using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class CancelAllOrdersParameter
    {
        [JsonProperty("product_code")]
        public ProductCode ProductCode { get; set; }
    }
}
