using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string SendCoinApiPath = "/v1/me/sendcoin";

        public async Task<PostResult> SendCoin(SendCoinParameter parameter, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Post<PostResult>(SendCoinApiPath, parameter, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
