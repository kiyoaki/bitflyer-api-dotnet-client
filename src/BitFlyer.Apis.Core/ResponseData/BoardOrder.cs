using Newtonsoft.Json;

namespace BitFlyer.Apis.Core.ResponseData
{
    public struct BoardOrder
    {
        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }
    }
}
