using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string CollateralApiPath = "/v1/me/getcollateral";

        public async Task<Collateral> GetCollateral(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Get<Collateral>(CollateralApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
