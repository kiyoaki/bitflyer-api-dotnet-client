using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class PostResult
    {
        [JsonPropertyName( "message_id")]
        public string MessageId { get; set; }

        [JsonPropertyName( "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [JsonPropertyName( "parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

