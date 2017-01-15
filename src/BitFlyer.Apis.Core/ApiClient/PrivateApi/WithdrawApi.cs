using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class BitFlyerPrivateApiClient
    {
        private const string WithdrawApiPath = "/v1/me/withdraw";

        public async Task<PostResult> Withdraw(WithdrawParameter parameter)
        {
            return await Post<PostResult>(WithdrawApiPath, parameter);
        }
    }
}
