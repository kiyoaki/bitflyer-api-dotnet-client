using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string MarketEuApiPath = "/v1/markets/eu";

        public static async Task<Market[]> GetMarketsEu(CancellationToken cancellationToken = default)
        {
            return await Get<Market[]>(MarketEuApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
