using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitFlyer.Apis.Test
{
    [TestClass]
    public class PublicApiTest
    {
        [TestMethod]
        public async Task GetBoard()
        {
            var res1 = await PublicApi.GetBoard(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await PublicApi.GetBoard(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await PublicApi.GetBoard(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [TestMethod]
        public async Task GetTicker()
        {
            var res1 = await PublicApi.GetTicker(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await PublicApi.GetTicker(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await PublicApi.GetTicker(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [TestMethod]
        public async Task GetExecutions()
        {
            var res1 = await PublicApi.GetExecutions(ProductCode.BtcJpy);
            Assert.AreNotEqual(res1, null);

            var res2 = await PublicApi.GetExecutions(ProductCode.FxBtcJpy);
            Assert.AreNotEqual(res2, null);

            var res3 = await PublicApi.GetExecutions(ProductCode.EthBtc);
            Assert.AreNotEqual(res3, null);
        }

        [TestMethod]
        public async Task GetHealth()
        {
            var res1 = await PublicApi.GetHealth();
            Assert.AreNotEqual(res1, null);
        }

        [TestMethod]
        public async Task GetChat()
        {
            var res1 = await PublicApi.GetChat(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.AreNotEqual(res1, null);
        }
    }
}
