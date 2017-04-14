using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class SendChildOrderParameter
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("child_order_type")]
        public ChildOrderType ChildOrderType { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("minute_to_expire")]
        public int MinuteToExpire { get; set; }

        [JsonProperty("time_in_force")]
        public TimeInForce TimeInForce { get; set; }

    }
}
