using System.Text.Json.Serialization;
using System.Text;
using System.Text.Json;

namespace BitFlyer.Apis
{
    public class BankAccount
    {
        [JsonPropertyName( "id")]
        public long Id { get; set; }

        [JsonPropertyName( "is_verified")]
        public bool IsVerified { get; set; }

        [JsonPropertyName( "bank_name")]
        public string BankName { get; set; }

        [JsonPropertyName( "branch_name")]
        public string BranchName { get; set; }

        [JsonPropertyName( "account_type")]
        public string AccountType { get; set; }

        [JsonPropertyName( "account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName( "account_name")]
        public string AccountName { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

