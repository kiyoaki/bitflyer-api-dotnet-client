using System;
using System.Threading.Tasks;
using Xunit;

namespace BitFlyer.Apis.Test
{
    public class PublicApiTest
    {
        [Fact]
        public async Task GetBoard()
        {
            var res1 = await PublicApi.GetBoard(ProductCode.BtcJpy);
            Assert.NotEqual(res1, null);

            var res2 = await PublicApi.GetBoard(ProductCode.FxBtcJpy);
            Assert.NotEqual(res2, null);

            var res3 = await PublicApi.GetBoard(ProductCode.EthBtc);
            Assert.NotEqual(res3, null);
        }

        [Fact]
        public async Task GetTicker()
        {
            var res1 = await PublicApi.GetTicker(ProductCode.BtcJpy);
            Assert.NotEqual(res1, null);

            var res2 = await PublicApi.GetTicker(ProductCode.FxBtcJpy);
            Assert.NotEqual(res2, null);

            var res3 = await PublicApi.GetTicker(ProductCode.EthBtc);
            Assert.NotEqual(res3, null);
        }

        [Fact]
        public async Task GetExecutions()
        {
            var res1 = await PublicApi.GetExecutions(ProductCode.BtcJpy);
            Assert.NotEqual(res1, null);

            var res2 = await PublicApi.GetExecutions(ProductCode.FxBtcJpy);
            Assert.NotEqual(res2, null);

            var res3 = await PublicApi.GetExecutions(ProductCode.EthBtc);
            Assert.NotEqual(res3, null);
        }

        [Fact]
        public async Task GetHealth()
        {
            var res1 = await PublicApi.GetHealth();
            Assert.NotEqual(res1, null);
        }

        [Fact]
        public async Task GetChat()
        {
            var res1 = await PublicApi.GetChat(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.NotEqual(res1, null);
        }
    }
}
