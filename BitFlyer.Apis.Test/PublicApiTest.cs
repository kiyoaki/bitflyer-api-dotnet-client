using System;
using System.Threading;
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
            Assert.NotNull(res1);

            var res2 = await PublicApi.GetBoard(ProductCode.FxBtcJpy);
            Assert.NotNull(res2);

            var res3 = await PublicApi.GetBoard(ProductCode.EthBtc);
            Assert.NotNull(res3);
        }

        [Fact]
        public async Task GetTicker()
        {
            var res1 = await PublicApi.GetTicker(ProductCode.BtcJpy);
            Assert.NotNull(res1);

            var res2 = await PublicApi.GetTicker(ProductCode.FxBtcJpy);
            Assert.NotNull(res2);

            var res3 = await PublicApi.GetTicker(ProductCode.EthBtc);
            Assert.NotNull(res3);
        }

        [Fact]
        public async Task GetExecutions()
        {
            var res1 = await PublicApi.GetExecutions(ProductCode.BtcJpy);
            Assert.NotNull(res1);

            var res2 = await PublicApi.GetExecutions(ProductCode.FxBtcJpy);
            Assert.NotNull(res2);

            var res3 = await PublicApi.GetExecutions(ProductCode.EthBtc);
            Assert.NotNull(res3);
        }

        [Fact]
        public async Task GetBoardState()
        {
            var res1 = await PublicApi.GetBoardState(ProductCode.BtcJpy);
            Assert.NotNull(res1);

            var res2 = await PublicApi.GetBoardState(ProductCode.FxBtcJpy);
            Assert.NotNull(res2);

            var res3 = await PublicApi.GetBoardState(ProductCode.EthBtc);
            Assert.NotNull(res3);

            var res4 = await PublicApi.GetBoardState("BTCJPY24NOV2017");
            Assert.NotNull(res4);
        }

        [Fact]
        public async Task GetHealth()
        {
            var res1 = await PublicApi.GetHealth(ProductCode.BtcJpy);
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetChat()
        {
            var res1 = await PublicApi.GetChat(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetMarkets()
        {
            var res1 = await PublicApi.GetMarkets();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetMarketsUsa()
        {
            var res1 = await PublicApi.GetMarketsUsa();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetChatUsa()
        {
            var res1 = await PublicApi.GetChatUsa(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetMarketsEu()
        {
            var res1 = await PublicApi.GetMarketsEu();
            Assert.NotNull(res1);
        }

        [Fact]
        public async Task GetChatEu()
        {
            var res1 = await PublicApi.GetChatEu(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.NotNull(res1);
        }
    }
}
