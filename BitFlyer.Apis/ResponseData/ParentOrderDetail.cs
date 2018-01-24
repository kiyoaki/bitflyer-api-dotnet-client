using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class ParentOrderDetail
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "parent_order_id")]
        public string ParentOrderId { get; set; }

        [DataMember(Name = "order_method")]
        public OrderMethod OrderMethod { get; set; }

        [DataMember(Name = "parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

        [DataMember(Name = "parameters")]
        public ParentOrderDetailParameter[] Parameters { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
