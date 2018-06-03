using System;

namespace Cryptrend.Core.Exchange
{
    public sealed class ExchangeName
    {


        public static readonly ExchangeName Bittrex = new ExchangeName("Bittrex");
        public static readonly ExchangeName Bitfinex = new ExchangeName("Bitfinex");
        public static readonly ExchangeName Binance = new ExchangeName("Binance");
        public static readonly ExchangeName Bithumb = new ExchangeName("Bithumb");
        public static readonly ExchangeName Bitstamp = new ExchangeName("Bitstamp");
        public static readonly ExchangeName GDAX = new ExchangeName("GDAX");
        public static readonly ExchangeName Gemini = new ExchangeName("Gemini");
        public static readonly ExchangeName Kraken = new ExchangeName("Kraken");
        public static readonly ExchangeName Poloniex = new ExchangeName("Poloniex");
        public static readonly ExchangeName Cryptowatch = new ExchangeName("Cryptowatch");

        private readonly string _value;

        public string Value
        {
            get { return _value; }
        }

        private ExchangeName(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value");
            _value = value;
        }

    }
}