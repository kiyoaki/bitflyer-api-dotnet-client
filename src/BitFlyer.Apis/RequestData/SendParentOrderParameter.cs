using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class SendParentOrderParameter
    {
        [JsonProperty("order_method")]
        public OrderMethod OrderMethod { get; set; }

        [JsonProperty("minute_to_expire")]
        public int MinuteToExpire { get; set; }

        [JsonProperty("time_in_force")]
        public TimeInForce TimeInForce { get; set; }

        [JsonProperty("parameters")]
        public ParentOrderDetailParameter[] Parameters { get; set; }
    }

    public class ParentOrderDetailParameter
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("condition_type")]
        public ConditionType ConditionType { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("trigger_price")]
        public double TriggerPrice { get; set; }

        [JsonProperty("offset")]
        public double Offset { get; set; }
    }
}
