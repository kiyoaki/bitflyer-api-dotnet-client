using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Health
    {
        [JsonProperty("status")]
        public BitflyerSystemHealth Status { get; set; }
    }
}
