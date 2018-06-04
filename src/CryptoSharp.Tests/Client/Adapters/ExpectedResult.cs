using CrypTrend.Core.Models;

namespace CryptoSharp.Tests.Client.Adapters
{
    public static class ExpectedResult
    {

        public static Ticker ExpectedTicker(string exchangeName)
        {
            return new Ticker(exchangeName, TradingPair.Create("ETH", "BTC"), 0.12345678m, 1.23456789m, 2.34567891m);
        }


    }
}