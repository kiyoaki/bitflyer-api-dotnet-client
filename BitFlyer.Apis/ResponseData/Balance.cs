using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class Balance
    {
        [JsonPropertyName( "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonPropertyName( "amount")]
        public double Amount { get; set; }

        [JsonPropertyName( "available")]
        public double Available { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

