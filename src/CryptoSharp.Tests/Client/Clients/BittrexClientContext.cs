using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Xml.Serialization;
using CryptoSharp.Client.Exchanges.Bittrex;
using CrypTrend.Core.Models;
using Moq;

namespace CryptoSharp.Tests.Client.Clients
{
    public class BittrexClientContext : IClientContext<IBittrexClient>
    {

        private TradingPairFormatOption _tradingPairFormatOption = TradingPairFormatOption.QuoteFirstDash;

        public Mock<IBittrexClient> GetClient()
        {

            var moq = new Mock<IBittrexClient>();

            moq.Setup(
                    x => x.GetTickerAsync(TradingPair.Create("ETH", "BTC").ToString(_tradingPairFormatOption), It.IsAny<CancellationToken>())).ReturnsAsync(
                 new TickerResult(){
                    Success = true,
                    Message = "",
                    Result = new CryptoSharp.Client.Exchanges.Bittrex.Ticker()
                    {
                        Ask = 0.12345678,
                        Bid = 1.23456789,
                        Last = 2.34567891,
                    }
                });

            moq.Setup(
                    x => x.GetTickerAsync(It.IsAny<string>()))
                .ReturnsAsync(new TickerResult()
                {
                    Success = false,
                    Message = "INVALID_MARKET",
                    Result = null
                });


            return moq;
            


        }


    }
}