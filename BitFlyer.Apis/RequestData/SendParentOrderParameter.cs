using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class SendParentOrderParameter
    {
        [DataMember(Name = "order_method")]
        public OrderMethod OrderMethod { get; set; }

        [DataMember(Name = "minute_to_expire")]
        public int MinuteToExpire { get; set; }

        [DataMember(Name = "time_in_force")]
        public TimeInForce TimeInForce { get; set; }

        [DataMember(Name = "parameters")]
        public ParentOrderDetailParameter[] Parameters { get; set; }
    }

    public class ParentOrderDetailParameter
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "condition_type")]
        public ConditionType ConditionType { get; set; }

        [DataMember(Name = "side")]
        public Side Side { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "trigger_price")]
        public double TriggerPrice { get; set; }

        [DataMember(Name = "offset")]
        public double Offset { get; set; }
    }
}
