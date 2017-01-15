using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPrivateApiClient
    {
        private const string BalanceApiPath = "/v1/me/getbalance";

        public async Task<Balance[]> GetBalance()
        {
            return await Get<Balance[]>(BalanceApiPath);
        }
    }
}
