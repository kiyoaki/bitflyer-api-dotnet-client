using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class BoardState
    {
        [JsonPropertyName( "health")]
        public BitflyerSystemHealth Health { get; set; }

        [JsonPropertyName( "state")]
        public BoardStates State { get; set; }

        [JsonPropertyName( "data")]
        public BoardStateData Data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class BoardStateData
    {
        [JsonPropertyName( "special_quotation")]
        public double SpecialQuotation { get; set; }
    }
}

