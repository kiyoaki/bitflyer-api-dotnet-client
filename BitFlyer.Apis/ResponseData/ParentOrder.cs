using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class ParentOrder
    {
        [JsonPropertyName( "id")]
        public int Id { get; set; }

        [JsonPropertyName( "parent_order_id")]
        public string ParentOrderId { get; set; }

        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName( "side")]
        public Side Side { get; set; }

        [JsonPropertyName( "parent_order_type")]
        public ParentOrderType ParentOrderType { get; set; }

        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "average_price")]
        public double AveragePrice { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        [JsonPropertyName( "parent_order_state")]
        public ParentOrderState ParentOrderState { get; set; }

        [JsonPropertyName( "expire_date")]
        public string ExpireDate { get; set; }

        [JsonPropertyName( "parent_order_date")]
        public DateTime ParentOrderDate { get; set; }

        [JsonPropertyName( "parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

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

