using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class CancelAllOrdersParameter
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }
    }
}
