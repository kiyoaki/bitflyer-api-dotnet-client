using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string DepositApiPath = "/v1/me/getdeposits";

        public async Task<Deposit[]> GetDeposits(CancellationToken cancellationToken = default)
        {
            return await Get<Deposit[]>(DepositApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
