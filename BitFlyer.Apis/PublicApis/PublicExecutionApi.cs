using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string ExecutionsApiPath = "/v1/executions";

        public static async Task<PublicExecution[]> GetExecutions(string productCode,
            int? count = null, int? before = null, int? after = null)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode }
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
