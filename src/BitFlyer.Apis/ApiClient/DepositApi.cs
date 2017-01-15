using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPrivateApiClient
    {
        private const string DepositApiPath = "/v1/me/getdeposits";

        public async Task<Deposit[]> GetDeposits()
        {
            return await Get<Deposit[]>(DepositApiPath);
        }
    }
}
