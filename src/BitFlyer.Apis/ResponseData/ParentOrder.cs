using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class ParentOrder
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent_order_id")]
        public string ParentOrderId { get; set; }

        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("parent_order_type")]
        public ParentOrderType ParentOrderType { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("average_price")]
        public double AveragePrice { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("parent_order_state")]
        public ParentOrderState ParentOrderState { get; set; }

        [JsonProperty("expire_date")]
        public string ExpireDate { get; set; }

        [JsonProperty("parent_order_date")]
        public DateTime ParentOrderDate { get; set; }

        [JsonProperty("parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

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
