using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string GetCollateralHistoryApiPath = "/v1/me/getcollateralhistory";

        public async Task<CollateralHistory[]> GetCollateralHistory(int? count = null, int? before = null, int? after = null)
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

            return await Get<CollateralHistory[]>(GetCollateralHistoryApiPath, query);
        }
    }
}
