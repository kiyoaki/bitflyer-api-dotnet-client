using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class PublicExecution
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "side")]
        public Side Side { get; set; }

        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        [JsonPropertyName( "exec_date")]
        public DateTime ExecDate { get; set; }

        [JsonPropertyName( "buy_child_order_acceptance_id")]
        public string BuyChildOrderAcceptanceId { get; set; }

        [JsonPropertyName( "sell_child_order_acceptance_id")]
        public string SellChildOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

