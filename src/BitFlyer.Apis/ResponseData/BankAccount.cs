using Newtonsoft.Json;

namespace BitFlyer.Apis
{
    public class BankAccount
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("branch_name")]
        public string BranchName { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("account_number")]
        public int AccountNumber { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
