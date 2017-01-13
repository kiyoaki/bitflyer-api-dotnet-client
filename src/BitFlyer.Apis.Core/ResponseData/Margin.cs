using Newtonsoft.Json;

namespace BitFlyer.Apis.Core.ResponseData
{
    public struct Margin
    {
        [JsonProperty("collateral")]
        public double Collateral { get; set; }

        [JsonProperty("open_position_pnl")]
        public double OpenPositionProfitOrLoss { get; set; }

        [JsonProperty("require_collateral")]
        public double RequireCollateral { get; set; }

        [JsonProperty("keep_rate")]
        public double KeepRate { get; set; }
    }
}
