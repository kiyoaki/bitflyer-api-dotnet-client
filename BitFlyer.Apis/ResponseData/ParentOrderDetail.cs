using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class ParentOrderDetail
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "parent_order_id")]
        public string ParentOrderId { get; set; }

        [JsonPropertyName( "order_method")]
        public OrderMethod OrderMethod { get; set; }

        [JsonPropertyName( "parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

        [JsonPropertyName( "parameters")]
        public ParentOrderDetailParameter[] Parameters { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

