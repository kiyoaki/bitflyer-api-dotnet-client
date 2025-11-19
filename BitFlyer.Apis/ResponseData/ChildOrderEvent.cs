using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class ChildOrderEvents
    {
        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName( "child_order_id")]
        public string ChildOrderId { get; set; }

        [JsonPropertyName( "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [JsonPropertyName( "event_date")]
        public string EventData { get; set; }

        [JsonPropertyName( "event_type")]
        public string EventType { get; set; }

        [JsonPropertyName( "child_order_type")]
        public string ChildOrderType { get; set; }

        [JsonPropertyName( "expire_date")]
        public string ExpireDate { get; set; }

        [JsonPropertyName( "reason")]
        public string Reason { get; set; }

        [JsonPropertyName( "exec_id")]
        public long ExecId { get; set; }

        [JsonPropertyName( "side")]
        public string Side { get; set; }

        [JsonPropertyName( "price")]
        public long Price { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        [JsonPropertyName( "commision")]
        public double Commision { get; set; }

        [JsonPropertyName( "sfd")]
        public double Sfd { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

