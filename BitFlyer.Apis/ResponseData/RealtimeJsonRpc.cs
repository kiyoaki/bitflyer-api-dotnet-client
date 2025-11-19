using System.Text.Json.Serialization;

namespace BitFlyer.Apis
{
    public partial class RealtimeJsonRpc<T>
    {
        [JsonPropertyName( "jsonrpc")]
        public string Jsonrpc { get; set; }

        [JsonPropertyName( "id")]
        public int? Id { get; set; }

        [JsonPropertyName( "result")]
        public bool? Result { get; set; }

        [JsonPropertyName( "method")]
        public string Method { get; set; }

        [JsonPropertyName( "params")]
        public Params<T> Params { get; set; }
    }

    public partial class Params<T>
    {
        [JsonPropertyName( "channel")]
        public string Channel { get; set; }

        [JsonPropertyName( "message")]
        public T Message { get; set; }
    }
}

