using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class CryptoCurrencyAddress
    {
        [DataMember(Name = "type")]
        public AddresseType Type { get; set; }

        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
