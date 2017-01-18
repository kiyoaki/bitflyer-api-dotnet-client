using System;
using System.Threading.Tasks;
using Xunit;

namespace BitFlyer.Apis.Test
{
    public class PublicApiTest
    {
        private readonly PublicApi _apiClient;

        public PublicApiTest()
        {
            _apiClient = new PublicApi();
        }

        [Fact]
        public async Task GetBoard()
        {
            var res1 = await _apiClient.GetBoard(ProductCode.BtcJpy);
            Assert.NotEqual(res1, null);

            var res2 = await _apiClient.GetBoard(ProductCode.FxBtcJpy);
            Assert.NotEqual(res2, null);

            var res3 = await _apiClient.GetBoard(ProductCode.EthBtc);
            Assert.NotEqual(res3, null);
        }

        [Fact]
        public async Task GetTicker()
        {
            var res1 = await _apiClient.GetTicker(ProductCode.BtcJpy);
            Assert.NotEqual(res1, null);

            var res2 = await _apiClient.GetTicker(ProductCode.FxBtcJpy);
            Assert.NotEqual(res2, null);

            var res3 = await _apiClient.GetTicker(ProductCode.EthBtc);
            Assert.NotEqual(res3, null);
        }

        [Fact]
        public async Task GetExecutions()
        {
            var res1 = await _apiClient.GetExecutions(ProductCode.BtcJpy);
            Assert.NotEqual(res1, null);

            var res2 = await _apiClient.GetExecutions(ProductCode.FxBtcJpy);
            Assert.NotEqual(res2, null);

            var res3 = await _apiClient.GetExecutions(ProductCode.EthBtc);
            Assert.NotEqual(res3, null);
        }

        [Fact]
        public async Task GetHealth()
        {
            var res1 = await _apiClient.GetHealth();
            Assert.NotEqual(res1, null);
        }

        [Fact]
        public async Task GetChat()
        {
            var res1 = await _apiClient.GetChat(DateTime.UtcNow.Subtract(TimeSpan.FromHours(1)));
            Assert.NotEqual(res1, null);
        }
    }
}
