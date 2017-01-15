using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitFlyer.Apis.Test
{
    [TestClass]
    public class PublicApiTest
    {
        private BitFlyerPublicApiClient _apiClient;

        [TestInitialize]
        public void TestInitialize()
        {
            _apiClient = new BitFlyerPublicApiClient();
        }

        [TestMethod]
        public async Task GetBoard()
        {
            var res1 = await _apiClient.GetBoard(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await _apiClient.GetBoard(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await _apiClient.GetBoard(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [TestMethod]
        public async Task GetTicker()
        {
            var res1 = await _apiClient.GetTicker(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await _apiClient.GetTicker(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await _apiClient.GetTicker(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [TestMethod]
        public async Task GetExecutions()
        {
            var res1 = await _apiClient.GetExecutions(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await _apiClient.GetExecutions(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await _apiClient.GetExecutions(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [TestMethod]
        public async Task GetHealth()
        {
            var res1 = await _apiClient.GetHealth();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetChat()
        {
            var res1 = await _apiClient.GetChat(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.AreNotEqual(res1, null);
        }
    }
}
