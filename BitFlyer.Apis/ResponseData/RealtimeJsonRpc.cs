using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public partial class RealtimeJsonRpc<T>
    {
        [DataMember(Name = "jsonrpc")]
        public string Jsonrpc { get; set; }

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        [DataMember(Name = "result")]
        public bool? Result { get; set; }

        [DataMember(Name = "method")]
        public string Method { get; set; }

        [DataMember(Name = "params")]
        public Params<T> Params { get; set; }
    }

    public partial class Params<T>
    {
        [DataMember(Name = "channel")]
        public string Channel { get; set; }

        [DataMember(Name = "message")]
        public T Message { get; set; }
    }
}
