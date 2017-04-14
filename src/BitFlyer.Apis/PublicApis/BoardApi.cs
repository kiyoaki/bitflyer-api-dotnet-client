using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string BoardApiPath = "/v1/board";

        public static async Task<Board> GetBoard(string productCode)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode }
            };
            return await Get<Board>(BoardApiPath, query);
        }
    }
}
