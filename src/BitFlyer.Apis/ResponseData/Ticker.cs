using System;
using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class Ticker
    {
        [JsonProperty("product_code")]
        public string ProductCode { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("tick_id")]
        public long TickId { get; set; }

        [JsonProperty("best_bid")]
        public double BestBid { get; set; }

        [JsonProperty("best_ask")]
        public double BestAsk { get; set; }

        [JsonProperty("best_bid_size")]
        public double BestBidSize { get; set; }

        [JsonProperty("best_ask_size")]
        public double BestAskSize { get; set; }

        [JsonProperty("total_bid_depth")]
        public double TotalBidDepth { get; set; }

        [JsonProperty("total_ask_depth")]
        public double TotalAskDepth { get; set; }

        [JsonProperty("ltp")]
        public double LatestPrice { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("volume_by_product")]
        public double VolumeByProduct { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
