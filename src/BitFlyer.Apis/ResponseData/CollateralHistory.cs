using System;
using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class CollateralHistory
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "change")]
        public double Change { get; set; }

        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "reason_code")]
        public CollateralReasonCode ResonCode { get; set; }

        [DataMember(Name = "date")]
        public DateTime date { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
