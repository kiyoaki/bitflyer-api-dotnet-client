using System.Text.Json;
using System.Text.Json.Serialization;

namespace BitFlyer.Apis
{
    public class Market
    {
        [JsonPropertyName( "product_code")]
        public string ProductCode { get; set; }

        [JsonPropertyName("market_type")]
        public string MarketType { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

