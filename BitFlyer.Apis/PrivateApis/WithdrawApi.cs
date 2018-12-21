using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string WithdrawApiPath = "/v1/me/withdraw";

        public async Task<PostResult> Withdraw(WithdrawParameter parameter, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Post<PostResult>(WithdrawApiPath, parameter, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
