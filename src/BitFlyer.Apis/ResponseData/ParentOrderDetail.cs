using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class ParentOrderDetail
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("parent_order_id")]
        public string ParentOrderId { get; set; }

        [JsonProperty("order_method")]
        public OrderMethod OrderMethod { get; set; }

        [JsonProperty("parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

        [JsonProperty("parameters")]
        public ParentOrderDetailParameter[] Parameters { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
