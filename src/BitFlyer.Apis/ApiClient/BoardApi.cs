using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPublicApiClient
    {
        private const string BoardApiPath = "/v1/board";

        public async Task<Board> GetBoard(ProductCode productCode)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode.Value() }
            };
            return await Get<Board>(BoardApiPath, query);
        }
    }
}
