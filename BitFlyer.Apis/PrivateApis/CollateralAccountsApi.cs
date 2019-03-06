using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string CollateralAccountsApiPath = "/v1/me/getcollateralaccounts";

        public async Task<CollateralAccount[]> GetCollateralAccounts(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Get<CollateralAccount[]>(CollateralAccountsApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
