using System;

namespace CrypTrend.Core.Models
{
    /// <summary>
    /// Report of the price for certain trading pair for a given exchange.
    /// </summary>
    public class Ticker
    {
        public Ticker(string exchangeName, TradingPair tradingPair, decimal ask, decimal bid, decimal last)
        {
            if(string.IsNullOrWhiteSpace(exchangeName)) throw new ArgumentNullException(nameof(exchangeName));
            if(tradingPair == null) throw new ArgumentNullException(nameof(tradingPair));
            ExchangeName = exchangeName;
            TradingPair = tradingPair;
            Ask = ask;
            Bid = bid;
            Last = last;
        }

        public Ticker(string exchangeName, TradingPair tradingPair, string id, decimal ask, decimal bid, decimal last) : this(exchangeName, tradingPair, ask, bid, last)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));
            Id = id;
        }

        /// <summary>
        /// Exchange Name
        /// </summary>
        public string ExchangeName { get; }

        /// <summary>
        /// Ticker TradingPair
        /// </summary>
        public TradingPair TradingPair { get; }

        /// <summary>
        /// An exchange specific id if known, otherwise null
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The bid is the price to sell at
        /// </summary>
        public decimal Bid { get; }

        /// <summary>
        /// The ask is the price to buy at
        /// </summary>
        public decimal Ask { get;  }

        /// <summary>
        /// The last trade purchase price
        /// </summary>
        public decimal Last { get; }


        public override string ToString()
        {
            return $"{ExchangeName} Ticker: {TradingPair}, Ask: {Ask:N8}, Bid: {Bid:N8}, Last: {Last:N8}";
        }
    }
}