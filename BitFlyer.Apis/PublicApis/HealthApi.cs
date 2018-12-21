using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string HealthApiPath = "/v1/gethealth";

        public static async Task<Health> GetHealth(string productCode = null)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode ?? ProductCode.BtcJpy }
            };
            return await Get<Health>(HealthApiPath, query).ConfigureAwait(false);
        }
    }
}
