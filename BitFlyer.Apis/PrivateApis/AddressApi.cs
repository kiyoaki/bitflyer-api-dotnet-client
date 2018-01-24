using System.Threading.Tasks;

namespace BitFlyer.Apis
{
    public partial class PrivateApi
    {
        private const string AddressesApiPath = "/v1/me/getaddresses";

        public async Task<CryptoCurrencyAddress[]> GetAddresses()
        {
            return await Get<CryptoCurrencyAddress[]>(AddressesApiPath);
        }
    }
}
