using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class BoardOrder
    {
        [JsonPropertyName( "price")]
        public double Price { get; set; }

        [JsonPropertyName( "size")]
        public double Size { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

