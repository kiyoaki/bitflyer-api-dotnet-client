using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class ChildOrder
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "child_order_id")]
        public string ChildOrderId { get; set; }

        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName( "side")]
        public Side Side { get; set; }

        [JsonPropertyName( "child_order_type")]
        public ChildOrderType ChildOrderType { get; set; }

        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "average_price")]
        public double AveragePrice { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        [JsonPropertyName( "child_order_state")]
        public ChildOrderState ChildOrderState { get; set; }

        [JsonPropertyName( "expire_date")]
        public string ExpireDate { get; set; }

        [JsonPropertyName( "child_order_date")]
        public string ChildOrderDate { get; set; }

        [JsonPropertyName( "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [JsonPropertyName( "outstanding_size")]
        public double OutstandingSize { get; set; }

        [JsonPropertyName( "cancel_size")]
        public double CancelSize { get; set; }

        [JsonPropertyName( "executed_size")]
        public double ExecutedSize { get; set; }

        [JsonPropertyName( "total_commission")]
        public double TotalCommission { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

