using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class CollateralHistory
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonPropertyName( "change")]
        public double Change { get; set; }

        [JsonPropertyName( "amount")]
        public double Amount { get; set; }

        [JsonPropertyName( "reason_code")]
        public CollateralReasonCode ResonCode { get; set; }

        [JsonPropertyName( "date")]
        public DateTime date { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

