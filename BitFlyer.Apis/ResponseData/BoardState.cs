using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class BoardState
    {
        [DataMember(Name = "health")]
        public BitflyerSystemHealth Health { get; set; }

        [DataMember(Name = "state")]
        public BoardStates State { get; set; }

        [DataMember(Name = "data")]
        public BoardStateData Data { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }

    public class BoardStateData
    {
        [DataMember(Name = "special_quotation")]
        public double SpecialQuotation { get; set; }
    }
}
