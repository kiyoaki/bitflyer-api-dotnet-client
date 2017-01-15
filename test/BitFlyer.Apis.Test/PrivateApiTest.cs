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
            _apiClient = BitFlyerPrivateApiClient.GetInstance(apiKey, apiSecret);
        }

        [TestMethod]
        public async Task ApiKeyNotFound()
        {
            var apiClient = BitFlyerPrivateApiClient.GetInstance("xxxxxxxxxxx", "xxxxxxxxxxx");
            try
            {
                var res1 = await apiClient.GetPermissions();
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
    }
}
