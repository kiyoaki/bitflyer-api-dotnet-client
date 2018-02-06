using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class BoardOrder
    {
        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "size")]
        public double Size { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
