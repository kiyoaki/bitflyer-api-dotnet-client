using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class CancelParentOrderParameter
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("parent_order_id")]
        public string ParentOrderId { get; set; }

        [JsonProperty("parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }
    }
}
