using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string BankAccountsApiPath = "/v1/me/getbankaccounts";

        public async Task<BankAccount[]> GetBankAccounts(CancellationToken cancellationToken = default)
        {
            return await Get<BankAccount[]>(BankAccountsApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
