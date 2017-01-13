using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BitFlyer.Apis.Core.RequestData
{
    public struct CurrencyWithdrawParameter
    {
        [JsonProperty("currency_code")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CurrencyCode CurrencyCode { get; set; }

        [JsonProperty("bank_account_id")]
        public long BankAccountId { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
