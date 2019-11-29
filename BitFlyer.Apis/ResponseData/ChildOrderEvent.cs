using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class ChildOrderEvents
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "child_order_id")]
        public string ChildOrderId { get; set; }

        [DataMember(Name = "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [DataMember(Name = "event_date")]
        public string EventData { get; set; }

        [DataMember(Name = "event_type")]
        public string EventType { get; set; }

        [DataMember(Name = "child_order_type")]
        public string ChildOrderType { get; set; }

        [DataMember(Name = "expire_date")]
        public string ExpireDate { get; set; }

        [DataMember(Name = "reason")]
        public string Reason { get; set; }

        [DataMember(Name = "exec_id")]
        public long ExecId { get; set; }

        [DataMember(Name = "side")]
        public string Side { get; set; }

        [DataMember(Name = "price")]
        public long Price { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "commision")]
        public double Commision { get; set; }

        [DataMember(Name = "sfd")]
        public double Sfd { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
