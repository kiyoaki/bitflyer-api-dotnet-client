using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class WithdrawParameter
    {
        [JsonProperty("currency_code")]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("bank_account_id")]
        public long BankAccountId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
