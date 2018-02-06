using System;
using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class PublicExecution
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "side")]
        public Side Side { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "exec_date")]
        public DateTime ExecDate { get; set; }

        [DataMember(Name = "buy_child_order_acceptance_id")]
        public string BuyChildOrderAcceptanceId { get; set; }

        [DataMember(Name = "sell_child_order_acceptance_id")]
        public string SellChildOrderAcceptanceId { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
