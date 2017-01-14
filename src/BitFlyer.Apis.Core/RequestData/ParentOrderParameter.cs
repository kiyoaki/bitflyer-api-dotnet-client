using System.Collections.Generic;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct ParentOrderParameter
    {
        [JsonProperty("order_method")]
        public OrderMethod OrderMethod { get; set; }

        [JsonProperty("minute_to_expire")]
        public int MinuteToExpire { get; set; }

        [JsonProperty("time_in_force")]
        public TimeInForce TimeInForce { get; set; }

        [JsonProperty("parameters")]
        public List<ParentOrderDetailParameter> Parameters { get; set; }
    }

    public class ParentOrderDetailParameter
    {
        [JsonProperty("product_code")]
        public ProductCode ProductCode { get; set; }

        [JsonProperty("condition_type")]
        public ConditionType ConditionType { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }
    }

    public class LimitOrder : ParentOrderDetailParameter
    {
        [JsonProperty("price")]
        public int Price { get; set; }
    }

    public class MarketOrder : ParentOrderDetailParameter
    {
    }

    public class StopOrder : ParentOrderDetailParameter
    {
        [JsonProperty("trigger_price")]
        public int TriggerPrice { get; set; }
    }

    public class ParentOrderStopLimitParameter : ParentOrderDetailParameter
    {
        [JsonProperty("price")]
        public int Price { get; set; }
    }

    public class ParentOrderStopTrailParameter : ParentOrderDetailParameter
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
