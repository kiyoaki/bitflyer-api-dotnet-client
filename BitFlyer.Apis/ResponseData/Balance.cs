using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class Balance
    {
        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "available")]
        public double Available { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
