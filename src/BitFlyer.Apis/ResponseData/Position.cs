using System;
using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Position
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "side")]
        public Side Side { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        [DataMember(Name = "commission")]
        public double Commission { get; set; }

        [DataMember(Name = "swap_point_accumulate")]
        public double SwapPointAccumulate { get; set; }

        [DataMember(Name = "require_collateral")]
        public double RequireCollateral { get; set; }

        [DataMember(Name = "open_date")]
        public DateTime OpenDate { get; set; }

        [DataMember(Name = "leverage")]
        public double Leverage { get; set; }

        [DataMember(Name = "pnl")]
        public double ProfitOrLoss { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
