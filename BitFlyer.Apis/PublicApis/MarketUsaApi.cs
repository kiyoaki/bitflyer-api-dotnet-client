using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string MarketUsaApiPath = "/v1/markets/usa";

        public static async Task<Market[]> GetMarketsUsa(CancellationToken cancellationToken = default)
        {
            return await Get<Market[]>(MarketUsaApiPath, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
