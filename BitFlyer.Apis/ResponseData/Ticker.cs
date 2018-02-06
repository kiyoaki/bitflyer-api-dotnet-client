using System;
using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Ticker
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "timestamp")]
        public DateTime Timestamp { get; set; }

        [DataMember(Name = "tick_id")]
        public long TickId { get; set; }

        [DataMember(Name = "best_bid")]
        public double BestBid { get; set; }

        [DataMember(Name = "best_ask")]
        public double BestAsk { get; set; }

        [DataMember(Name = "best_bid_size")]
        public double BestBidSize { get; set; }

        [DataMember(Name = "best_ask_size")]
        public double BestAskSize { get; set; }

        [DataMember(Name = "total_bid_depth")]
        public double TotalBidDepth { get; set; }

        [DataMember(Name = "total_ask_depth")]
        public double TotalAskDepth { get; set; }

        [DataMember(Name = "ltp")]
        public double LatestPrice { get; set; }

        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        [DataMember(Name = "volume_by_product")]
        public double VolumeByProduct { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
