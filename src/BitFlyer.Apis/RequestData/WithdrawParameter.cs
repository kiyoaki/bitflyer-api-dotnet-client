using System.Runtime.Serialization;

namespace BitFlyer.Apis
{
    public class WithdrawParameter
    {
        [DataMember(Name = "currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [DataMember(Name = "bank_account_id")]
        public long BankAccountId { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "code")]
        public int Code { get; set; }
    }
}
