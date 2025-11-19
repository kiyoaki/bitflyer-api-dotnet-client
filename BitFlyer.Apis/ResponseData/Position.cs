using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class Position
    {
        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName( "side")]
        public Side Side { get; set; }

        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        [JsonPropertyName( "commission")]
        public double Commission { get; set; }

        [JsonPropertyName( "swap_point_accumulate")]
        public double SwapPointAccumulate { get; set; }

        [JsonPropertyName( "require_collateral")]
        public double RequireCollateral { get; set; }

        [JsonPropertyName( "open_date")]
        public DateTime OpenDate { get; set; }

        [JsonPropertyName( "leverage")]
        public double Leverage { get; set; }

        [JsonPropertyName( "pnl")]
        public double ProfitOrLoss { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

