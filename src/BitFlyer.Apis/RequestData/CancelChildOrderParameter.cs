using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class CancelChildOrderParameter
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("child_order_id")]
        public string ChildOrderId { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }
    }
}
