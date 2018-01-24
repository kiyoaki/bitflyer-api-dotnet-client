using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PublicApi
    {
        private const string HealthApiPath = "/v1/gethealth";

        public static async Task<Health> GetHealth()
        {
            return await Get<Health>(HealthApiPath);
        }
    }
}
