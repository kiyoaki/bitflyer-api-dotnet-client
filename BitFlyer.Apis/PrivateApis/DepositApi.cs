using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string DepositApiPath = "/v1/me/getdeposits";

        public async Task<Deposit[]> GetDeposits()
        {
            return await Get<Deposit[]>(DepositApiPath);
        }
    }
}
