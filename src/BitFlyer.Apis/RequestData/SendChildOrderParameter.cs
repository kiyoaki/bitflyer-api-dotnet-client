using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class SendChildOrderParameter
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "child_order_type")]
        public ChildOrderType ChildOrderType { get; set; }

        [DataMember(Name = "side")]
        public Side Side { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "minute_to_expire")]
        public int MinuteToExpire { get; set; }

        [DataMember(Name = "time_in_force")]
        public TimeInForce TimeInForce { get; set; }

    }
}
