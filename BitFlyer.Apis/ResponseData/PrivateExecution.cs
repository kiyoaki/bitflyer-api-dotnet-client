using System;
using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class PrivateExecution
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "child_order_id")]
        public string ChildOrderId { get; set; }

        [DataMember(Name = "side")]
        public Side Side { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "commission")]
        public double Commission { get; set; }

        [DataMember(Name = "exec_date")]
        public DateTime ExecDate { get; set; }

        [DataMember(Name = "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
