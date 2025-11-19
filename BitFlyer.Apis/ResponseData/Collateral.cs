using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class Collateral
    {
        [JsonPropertyName( "collateral")]
        public double Amount { get; set; }

        [JsonPropertyName( "open_position_pnl")]
        public double OpenPositionProfitOrLoss { get; set; }

        [JsonPropertyName( "require_collateral")]
        public double RequireCollateral { get; set; }

        [JsonPropertyName( "keep_rate")]
        public double KeepRate { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

