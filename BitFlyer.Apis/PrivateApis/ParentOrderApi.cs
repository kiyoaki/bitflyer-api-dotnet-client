using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string SendParentOrderApiPath = "/v1/me/sendparentorder";
        private const string CancelParentOrderApiPath = "/v1/me/cancelparentorder";
        private const string GetParentOrderApiPath = "/v1/me/getparentorder";
        private const string GetParentOrdersApiPath = "/v1/me/getparentorders";

        public async Task<PostResult> SendParentOrder(SendParentOrderParameter parameter, CancellationToken cancellationToken = default)
        {
            return await Post<PostResult>(SendParentOrderApiPath, parameter, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task CancelParentOrder(CancelParentOrderParameter parameter, CancellationToken cancellationToken = default)
        {
            await Post(CancelParentOrderApiPath, parameter, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ParentOrderDetail> GetParentOrder(string productCode,
            string parentOrderId = null, string parentOrderAcceptanceId = null,
            CancellationToken cancellationToken = default)
        {
            if (parentOrderId == null && parentOrderAcceptanceId == null)
            {
                throw new BitFlyerApiException(GetParentOrderApiPath,
                    "parentOrderId or parentOrderAcceptanceId is required.");
            }

            var query = new Dictionary<string, object>
            {
                { "product_code", productCode }
            };

            if (parentOrderId != null)
            {
                query["parent_order_id"] = parentOrderId;
            }
            if (parentOrderAcceptanceId != null)
            {
                query["parent_order_acceptance_id"] = parentOrderAcceptanceId;
            }

            return await Get<ParentOrderDetail>(GetParentOrderApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ParentOrder[]> GetParentOrders(string productCode,
            int? count = null, int? before = null, int? after = null,
            ParentOrderState parentOrderState = ParentOrderState.Active,
            CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode },
                { "parent_order_state", parentOrderState.GetEnumMemberValue() }
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

            return await Get<ParentOrder[]>(GetParentOrdersApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
