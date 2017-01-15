using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct Collateral
    {
        [JsonProperty("collateral")]
        public double Amount { get; set; }

        [JsonProperty("open_position_pnl")]
        public double OpenPositionProfitOrLoss { get; set; }

        [JsonProperty("require_collateral")]
        public double RequireCollateral { get; set; }

        [JsonProperty("keep_rate")]
        public double KeepRate { get; set; }
    }
}
