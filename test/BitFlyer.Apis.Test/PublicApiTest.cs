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
            var res = await BitFlyerPublicApiClient.GetInstance().GetBoard(ProductCode.BtcJpy);
            Assert.AreNotEqual(res, null);
        }

        [TestMethod]
        public async Task GetExecutions()
        {
            var res = await BitFlyerPublicApiClient.GetInstance().GetExecutions(ProductCode.BtcJpy);
            Assert.AreNotEqual(res, null);
        }

        [TestMethod]
        public async Task GetTicker()
        {
            var res = await BitFlyerPublicApiClient.GetInstance().GetTicker(ProductCode.BtcJpy);
            Assert.AreNotEqual(res, null);
        }
    }
}
