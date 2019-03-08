using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string HealthApiPath = "/v1/gethealth";

        public static async Task<Health> GetHealth(string productCode = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object>
            {
                { "product_code", productCode ?? ProductCode.BtcJpy }
            };
            return await Get<Health>(HealthApiPath, query, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
