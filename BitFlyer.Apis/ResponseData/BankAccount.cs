using System.Runtime.Serialization;
using System.Text;
using Utf8Json;

namespace BitFlyer.Apis
{
    public class BankAccount
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "is_verified")]
        public bool IsVerified { get; set; }

        [DataMember(Name = "bank_name")]
        public string BankName { get; set; }

        [DataMember(Name = "branch_name")]
        public string BranchName { get; set; }

        [DataMember(Name = "account_type")]
        public string AccountType { get; set; }

        [DataMember(Name = "account_number")]
        public string AccountNumber { get; set; }

        [DataMember(Name = "account_name")]
        public string AccountName { get; set; }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(JsonSerializer.Serialize(this));
        }
    }
}
