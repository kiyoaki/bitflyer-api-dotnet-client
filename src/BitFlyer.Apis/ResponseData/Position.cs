using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Position
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("commission")]
        public double Commission { get; set; }

        [JsonProperty("swap_point_accumulate")]
        public double SwapPointAccumulate { get; set; }

        [JsonProperty("require_collateral")]
        public double RequireCollateral { get; set; }

        [JsonProperty("open_date")]
        public DateTime OpenDate { get; set; }

        [JsonProperty("leverage")]
        public double Leverage { get; set; }

        [JsonProperty("pnl")]
        public double ProfitOrLoss { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
