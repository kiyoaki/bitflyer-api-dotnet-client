using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string SendChildOrderApiPath = "/v1/me/sendchildorder";
        private const string CancelChildOrderApiPath = "/v1/me/cancelchildorder";
        private const string CancelAllOrdersApiPath = "/v1/me/cancelallchildorders";
        private const string GetChildOrdersApiPath = "/v1/me/getchildorders";

        public async Task<PostResult> SendChildOrder(SendChildOrderParameter parameter, CancellationToken cancellationToken = default)
        {
            return await Post<PostResult>(SendChildOrderApiPath, parameter, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task CancelChildOrder(CancelChildOrderParameter parameter, CancellationToken cancellationToken = default)
        {
            await Post(CancelChildOrderApiPath, parameter, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task CancelAllOrders(CancelAllOrdersParameter parameter, CancellationToken cancellationToken = default)
        {
            await Post(CancelAllOrdersApiPath, parameter, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ChildOrder[]> GetChildOrders(string productCode,
            int? count = null, int? before = null, int? after = null, ChildOrderState? childOrderState = null,
            CancellationToken cancellationToken = default)
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
            if (childOrderState != null)
            {
                query["child_order_state"] = childOrderState.GetEnumMemberValue();
            }

            return await Get<ChildOrder[]>(GetChildOrdersApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ChildOrder[]> GetChildOrder(string productCode, long childOrderId, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode },
                { "child_order_id", childOrderId }
            };

            return await Get<ChildOrder[]>(GetChildOrdersApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
