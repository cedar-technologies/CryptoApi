using System;
using CryptoSharp.Client.Exchanges.Bittrex;
using CrypTrend.Client.Adapters;
using CrypTrend.Core.Models;

namespace CryptoSharp.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CryptoSharp Sample");

            var adapter = new BittrexAdapter(new BittrexClient());

            var tradingPair = new TradingPair("ETH", "BTC");

            var ticker = adapter.GetTickerAsync(tradingPair).Result;

            Console.WriteLine(ticker);

            Console.ReadKey();
        }
    }
}
