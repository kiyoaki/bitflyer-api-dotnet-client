using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string BalanceApiPath = "/v1/me/getbalance";

        public async Task<Balance[]> GetBalance()
        {
            return await Get<Balance[]>(BalanceApiPath);
        }
    }
}
