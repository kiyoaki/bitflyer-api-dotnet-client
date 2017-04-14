using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class ChildOrder
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("child_order_id")]
        public string ChildOrderId { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("child_order_type")]
        public ChildOrderType ChildOrderType { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("average_price")]
        public double AveragePrice { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("child_order_state")]
        public ChildOrderState ChildOrderState { get; set; }

        [JsonProperty("expire_date")]
        public string ExpireDate { get; set; }

        [JsonProperty("child_order_date")]
        public string ChildOrderDate { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [JsonProperty("outstanding_size")]
        public double OutstandingSize { get; set; }

        [JsonProperty("cancel_size")]
        public double CancelSize { get; set; }

        [JsonProperty("executed_size")]
        public double ExecutedSize { get; set; }

        [JsonProperty("total_commission")]
        public double TotalCommission { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
