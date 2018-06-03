using System;
using CrypTrend.Core.Models;

namespace CryptoSharp.Client.Mappers
{
    public static class TickerExtensions
    {
        public static Ticker ToTicker(this Exchanges.Bittrex.Ticker ticker, TradingPair tradingPair, string exchangeName)
        {
            return new Ticker(
                exchangeName,
                tradingPair,
                Convert.ToDecimal(ticker.Ask),
                Convert.ToDecimal(ticker.Bid),
                Convert.ToDecimal(ticker.Last));   
        }
    }
}