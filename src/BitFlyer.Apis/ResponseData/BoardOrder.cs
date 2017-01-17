using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class BoardOrder
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
