using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Collateral
    {
        [DataMember(Name = "collateral")]
        public double Amount { get; set; }

        [DataMember(Name = "open_position_pnl")]
        public double OpenPositionProfitOrLoss { get; set; }

        [DataMember(Name = "require_collateral")]
        public double RequireCollateral { get; set; }

        [DataMember(Name = "keep_rate")]
        public double KeepRate { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
