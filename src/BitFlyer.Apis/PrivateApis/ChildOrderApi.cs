using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string SendChildOrderApiPath = "/v1/me/sendchildorder";
        private const string CancelChildOrderApiPath = "/v1/me/cancelchildorder";
        private const string CancelAllOrdersApiPath = "/v1/me/cancelallchildorders";
        private const string GetChildOrdersApiPath = "/v1/me/getchildorders";

        public async Task<PostResult> SendChildOrder(SendChildOrderParameter parameter)
        {
            return await Post<PostResult>(SendChildOrderApiPath, parameter);
        }

        public async Task CancelChildOrder(CancelChildOrderParameter parameter)
        {
            await Post(CancelChildOrderApiPath, parameter);
        }

        public async Task CancelAllOrders(CancelAllOrdersParameter parameter)
        {
            await Post(CancelAllOrdersApiPath, parameter);
        }

        public async Task<ChildOrder[]> GetChildOrders(string productCode,
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

            return await Get<ChildOrder[]>(GetChildOrdersApiPath, query);
        }
    }
}
