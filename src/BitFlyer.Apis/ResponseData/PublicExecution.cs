using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class PublicExecution
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("exec_date")]
        public DateTime ExecDate { get; set; }

        [JsonProperty("buy_child_order_acceptance_id")]
        public string BuyChildOrderAcceptanceId { get; set; }

        [JsonProperty("sell_child_order_acceptance_id")]
        public string SellChildOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
