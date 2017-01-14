using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct Health
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public BitflyerSystemHealth SystemHealth
        {
            get
            {
                BitflyerSystemHealth x;
                return BitFlyerConstants.Healths.TryGetValue(Status, out x) ? x : BitflyerSystemHealth.Stop;
            }
        }
    }
}
