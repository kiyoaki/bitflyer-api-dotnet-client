using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPublicApiClient
    {
        private const string ExecutionsApiPath = "/v1/executions";

        public async Task<PublicExecution[]> GetExecutions(ProductCode productCode,
            int? count = null, int? before = null, int? after = null)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode.Value() }
            };

            if (count != null)
            {
                query["count"] = count.Value;
            }
            if (before != null)
            {
                query["before"] = before.Value;
            }
            if (after != null)
            {
                query["after"] = after.Value;
            }

            return await Get<PublicExecution[]>(ExecutionsApiPath, query);
        }
    }
}
