using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class CancelChildOrderParameter
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "child_order_id")]
        public string ChildOrderId { get; set; }

        [DataMember(Name = "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }
    }
}
