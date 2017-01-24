using System;
using Newtonsoft.Json;

namespace BitFlyer.Sample.OkCoin
{
    public class Ticker
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("data")]
        public TickerItem Data { get; set; }
    }

    public class TickerItem
    {
        [JsonIgnore]
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        [JsonProperty("buy")]
        public double Buy { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("sell")]
        public double Sell { get; set; }

        [JsonProperty("timestamp")]
        public long Unixtime { get; set; }

        [JsonIgnore]
        public DateTime Timestamp => UnixEpoch.AddSeconds(Math.Round(Unixtime / 1000.0)).ToLocalTime();

        [JsonProperty("vol")]
        public double Volume { get; set; }
    }
}
