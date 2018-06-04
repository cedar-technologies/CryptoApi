using CryptoSharp.Client.Exchanges.Bittrex;
using CryptoSharp.Tests.Client.Clients;
using CrypTrend.Client.Adapters;
using CrypTrend.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CryptoSharp.Tests.Client.Adapters
{
    [TestClass]
    public class BittrexAdapterTests
    {

        protected BittrexAdapter _sut;
        protected IClientContext<IBittrexClient> _ctx;

        [TestInitialize]
        public void Init()
        {
            _ctx = new BittrexClientContext();
            _sut = new BittrexAdapter(_ctx.GetClient().Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestClass]
        public class GetTickerTests  : BittrexAdapterTests
        {

            [TestMethod]
            public void GetTicker_BTCETH_Test()
            {
                var expectedResult = ExpectedResult.ExpectedTicker(_sut.Name);

                var result = _sut.GetTickerAsync(TradingPair.Create("ETH", "BTC")).Result;

                Assert.IsTrue(
                    JsonConvert.SerializeObject(expectedResult) == 
                    JsonConvert.SerializeObject(result));
            }


        }
    }
}