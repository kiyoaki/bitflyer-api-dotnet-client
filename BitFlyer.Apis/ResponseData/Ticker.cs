using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class Ticker
    {
        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName( "timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName( "tick_id")]
        public long TickId { get; set; }

        [JsonPropertyName( "best_bid")]
        public double BestBid { get; set; }

        [JsonPropertyName( "best_ask")]
        public double BestAsk { get; set; }

        [JsonPropertyName( "best_bid_size")]
        public double BestBidSize { get; set; }

        [JsonPropertyName( "best_ask_size")]
        public double BestAskSize { get; set; }

        [JsonPropertyName( "total_bid_depth")]
        public double TotalBidDepth { get; set; }

        [JsonPropertyName( "total_ask_depth")]
        public double TotalAskDepth { get; set; }

        [JsonPropertyName( "ltp")]
        public double LatestPrice { get; set; }

        [JsonPropertyName( "volume")]
        public double Volume { get; set; }

        [JsonPropertyName( "volume_by_product")]
        public double VolumeByProduct { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

