using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetPositionsApiPath = "/v1/me/getpositions";

        public async Task<Position[]> GetPositions(string productCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Get<Position[]>(GetPositionsApiPath, new Dictionary<string, object>
            {
                { "product_code", productCode }
            }, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
