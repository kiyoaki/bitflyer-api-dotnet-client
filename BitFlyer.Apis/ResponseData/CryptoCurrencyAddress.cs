using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class CryptoCurrencyAddress
    {
        [JsonPropertyName( "type")]
        public AddresseType Type { get; set; }

        [JsonPropertyName( "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonPropertyName( "address")]
        public string Address { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

