using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class ChildOrder
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "child_order_id")]
        public string ChildOrderId { get; set; }

        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "side")]
        public Side Side { get; set; }

        [DataMember(Name = "child_order_type")]
        public ChildOrderType ChildOrderType { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "average_price")]
        public double AveragePrice { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "child_order_state")]
        public ChildOrderState ChildOrderState { get; set; }

        [DataMember(Name = "expire_date")]
        public string ExpireDate { get; set; }

        [DataMember(Name = "child_order_date")]
        public string ChildOrderDate { get; set; }

        [DataMember(Name = "child_order_acceptance_id")]
        public string ChildOrderAcceptanceId { get; set; }

        [DataMember(Name = "outstanding_size")]
        public double OutstandingSize { get; set; }

        [DataMember(Name = "cancel_size")]
        public double CancelSize { get; set; }

        [DataMember(Name = "executed_size")]
        public double ExecutedSize { get; set; }

        [DataMember(Name = "total_commission")]
        public double TotalCommission { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
