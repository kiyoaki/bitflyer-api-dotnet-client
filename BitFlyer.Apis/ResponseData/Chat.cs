using System;
using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class Chat
    {
        [JsonPropertyName( "nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName( "message")]
        public string Message { get; set; }

        [JsonPropertyName( "date")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

