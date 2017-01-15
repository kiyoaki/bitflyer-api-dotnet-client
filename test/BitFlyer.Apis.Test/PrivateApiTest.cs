using System.Configuration;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitFlyer.Apis.Test
{
    [TestClass]
    public class PrivateApiTest
    {
        private BitFlyerPrivateApiClient _apiClient;

        [TestInitialize]
        public void TestInitialize()
        {
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            var apiSecret = ConfigurationManager.AppSettings["ApiSecret"];
            _apiClient = new BitFlyerPrivateApiClient(apiKey, apiSecret);
        }

        [TestMethod]
        public async Task ApiKeyNotFound()
        {
            var apiClient = new BitFlyerPrivateApiClient("xxxxxxxxxxx", "xxxxxxxxxxx");
            try
            {
                await apiClient.GetPermissions();
            }
            catch (BitFlyerApiException ex)
            {
                Assert.AreEqual(ex.ErrorResponse.Status, -500);
                Assert.AreEqual(ex.ErrorResponse.ErrorMessage, "Key not found");
            }
        }

        [TestMethod]
        public async Task GetPermissions()
        {
            var res1 = await _apiClient.GetPermissions();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetBalance()
        {
            var res1 = await _apiClient.GetBalance();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetCollateral()
        {
            var res1 = await _apiClient.GetCollateral();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetAddresses()
        {
            var res1 = await _apiClient.GetAddresses();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetCoinIns()
        {
            var res1 = await _apiClient.GetCoinIns();
            Assert.AreNotEqual(res1, null);
        }

        /*
        [TestMethod]
        public async Task SendCoin()
        {
            var res1 = await _apiClient.SendCoin(new SendCoinParameter
            {
                CurrencyCode = CurrencyCode.Btc,
                Amount = 0.001,
                AdditionalFee = 0,
                Address = "xxxxxx",
                Code = 123456
            });
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetCoinOut()
        {
            var res1 = await _apiClient.GetCoinOut("xxxxx");
            Assert.AreNotEqual(res1, null);
        }
        */

        [TestMethod]
        public async Task GetCoinOuts()
        {
            var res1 = await _apiClient.GetCoinOuts();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetBankAccounts()
        {
            var res1 = await _apiClient.GetBankAccounts();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetDeposits()
        {
            var res1 = await _apiClient.GetDeposits();
            Assert.AreNotEqual(res1, null);
        }

        /*
        [TestMethod]
        public async Task Withdraw()
        {
            var res1 = await _apiClient.Withdraw(new WithdrawParameter
            {
                CurrencyCode = CurrencyCode.Jpy,
                Amount = 1,
                BankAccountId = 1234567890,
                Code = 123456
            });
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetWithdrawal()
        {
            var res1 = await _apiClient.GetWithdrawal("xxxxx");
            Assert.AreNotEqual(res1, null);
        }
        */

        [TestMethod]
        public async Task GetWithdrawals()
        {
            var res1 = await _apiClient.GetWithdrawals();
            Assert.AreNotEqual(res1, null);
        }
    }
}
