using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class PostResult
    {
        [DataMember(Name = "message_id")]
        public string MessageId { get; set; }

        [DataMember(Name = "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [DataMember(Name = "parent_order_acceptance_id")]
        public string ParentOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
