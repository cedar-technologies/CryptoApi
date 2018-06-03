using CrypTrend.Core.Models;

namespace CryptoSharp.Client.Queries
{
    public class TickerQuery
    {
        public class Get
        {
            private TradingPair _tradingPair;
            private string _exchangeName;

            public TradingPair TradingPair => _tradingPair;
            public string ExchangeName => _exchangeName;

            public Get(TradingPair tradingPair, string exchangeName)
            {
                _tradingPair = tradingPair;
                _exchangeName = exchangeName;
            }
        }
    }
}