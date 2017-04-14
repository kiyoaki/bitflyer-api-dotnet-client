using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class CancelAllOrdersParameter
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }
    }
}
