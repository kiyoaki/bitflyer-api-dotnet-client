using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class SendCoinParameter
    {
        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "amount")]
        public double Amount { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "additional_fee")]
        public double AdditionalFee { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
