using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPrivateApiClient
    {
        private const string BankAccountsApiPath = "/v1/me/getbankaccounts";

        public async Task<BankAccount[]> GetBankAccounts()
        {
            return await Get<BankAccount[]>(BankAccountsApiPath);
        }
    }
}
