using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Market
    {
        [DataMember(Name = "product_code")]
        public string ProductCode { get; set; }

        [DataMember(Name = "alias")]
        public ProductAlias ProductAlias { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
