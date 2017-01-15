using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPublicApiClient
    {
        private const string HealthApiPath = "/v1/gethealth";

        public async Task<Health> GetHealth()
        {
            return await Get<Health>(HealthApiPath);
        }
    }
}
