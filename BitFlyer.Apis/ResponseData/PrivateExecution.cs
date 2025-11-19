using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class PrivateExecution
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "child_order_id")]
        public string ChildOrderId { get; set; }

        [JsonPropertyName( "side")]
        public Side Side { get; set; }

        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        [JsonPropertyName( "commission")]
        public double Commission { get; set; }

        [JsonPropertyName( "exec_date")]
        public DateTime ExecDate { get; set; }

        [JsonPropertyName( "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

