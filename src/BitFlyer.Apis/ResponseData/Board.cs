using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Board
    {
        [JsonProperty("mid_price")]
        public double MiddlePrice { get; set; }

        [JsonProperty("asks")]
        public BoardOrder[] Asks { get; set; }

        [JsonProperty("bids")]
        public BoardOrder[] Bids { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
