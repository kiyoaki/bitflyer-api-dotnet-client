using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetWithdrawalsApiPath = "/v1/me/getwithdrawals";

        public async Task<Withdrawal> GetWithdrawal(string messageId)
        {
            if (messageId == null)
            {
                throw new ArgumentNullException(nameof(messageId));
            }

            var query = new Dictionary<string, object>
            {
                { "message_id", messageId }
            };

            return await Get<Withdrawal>(GetWithdrawalsApiPath, query);
        }

        public async Task<Withdrawal[]> GetWithdrawals(int? count = null, int? before = null, int? after = null)
        {
            var query = new Dictionary<string, object>();

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

            return await Get<Withdrawal[]>(GetWithdrawalsApiPath, query);
        }
    }
}
