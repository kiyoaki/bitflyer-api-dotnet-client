using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string MarketApiPath = "/v1/markets";

        public static async Task<Market[]> GetMarkets(CancellationToken cancellationToken = default)
        {
            return await Get<Market[]>(MarketApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
