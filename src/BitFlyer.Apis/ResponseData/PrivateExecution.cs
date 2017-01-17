using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class PrivateExecution
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("child_order_id")]
        public string ChildOrderId { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("commission")]
        public double Commission { get; set; }

        [JsonProperty("exec_date")]
        public DateTime ExecDate { get; set; }

        [JsonProperty("child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
