using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetExecutionsApiPath = "/v1/me/getexecutions";

        public async Task<PrivateExecution[]> GetExecutions(string productCode,
            int? count = null, int? before = null, int? after = null,
            string childOrderId = null, string childOrderAcceptanceId = null)
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
            if (childOrderId != null)
            {
                query["child_order_id"] = childOrderId;
            }
            if (childOrderAcceptanceId != null)
            {
                query["child_order_acceptance_id"] = childOrderAcceptanceId;
            }

            return await Get<PrivateExecution[]>(GetExecutionsApiPath, query);
        }
    }
}
