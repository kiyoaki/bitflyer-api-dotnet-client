using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string BoardStateApiPath = "/v1/getboardstate";

        public static async Task<BoardState> GetBoardState(string productCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode }
            };
            return await Get<BoardState>(BoardStateApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
