using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Board
    {
        [DataMember(Name = "mid_price")]
        public double MiddlePrice { get; set; }

        [DataMember(Name = "asks")]
        public BoardOrder[] Asks { get; set; }

        [DataMember(Name = "bids")]
        public BoardOrder[] Bids { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
