using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class CancelChildOrderParameter
    {
        [JsonProperty("product_code")]
        public ProductCode ProductCode { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }
    }
}
