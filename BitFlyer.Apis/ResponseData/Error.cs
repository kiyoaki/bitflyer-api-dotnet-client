using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class Error
    {
        [JsonPropertyName( "status")]
        public int Status { get; set; }

        [JsonPropertyName( "error_message")]
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

