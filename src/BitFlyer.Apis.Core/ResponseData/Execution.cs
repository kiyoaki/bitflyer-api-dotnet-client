using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis.Core.ResponseData
{
    public struct Execution
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Side Side { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("exec_date")]
        public DateTime ExecDate { get; set; }

        [JsonProperty("buy_child_order_acceptance_id")]
        public string BuyChildOrderAcceptanceId { get; set; }

        [JsonProperty("sell_child_order_acceptance_id")]
        public string SellChildOrderAcceptanceId { get; set; }
    }
}
