using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class CancelParentOrderParameter
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "parent_order_id")]
        public string ParentOrderId { get; set; }

        [DataMember(Name = "parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }
    }
}
