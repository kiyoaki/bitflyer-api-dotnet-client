using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetPositionsApiPath = "/v1/me/getpositions";

        public async Task<Position[]> GetPositions(ProductCode productCode)
        {
            return await Get<Position[]>(GetPositionsApiPath, new Dictionary<string, object>
            {
                { "product_code", productCode.GetEnumMemberValue() }
            });
        }
    }
}
