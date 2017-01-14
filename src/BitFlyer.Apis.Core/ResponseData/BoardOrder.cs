using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public struct BoardOrder
    {
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }
    }
}
