using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct BoardOrder
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }
    }
}
