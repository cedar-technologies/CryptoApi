using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoSharp.Client.Exchanges.Bittrex;
using Cryptrend.Core.Exchange;
using CrypTrend.Adapter.Adapters;
using CrypTrend.Core.Models;

namespace CrypTrend.Client.Adapters
{
    public class BittrexAdapter : IExchangeAdapter
    {

        private readonly IBittrexClient _bittrexClient;

        public string Name => ExchangeName.Bittrex.Value;
        public TradingPairFormatOption TradingPairFormatOption => TradingPairFormatOption.QuoteFirstDash;

        public BittrexAdapter(IBittrexClient bittrexClient)
        {
            if(bittrexClient == null) throw new ArgumentNullException(typeof(IBittrexClient).Name);
           _bittrexClient = bittrexClient;
        }

        public async Task<Core.Models.Ticker> GetTickerAsync(TradingPair tradingPair)
        {
            return await GetTickerAsync(tradingPair, CancellationToken.None);
        }

        public async Task<Core.Models.Ticker> GetTickerAsync(TradingPair tradingPair, CancellationToken cancellationToken)
        {
            var result = await _bittrexClient.GetTickerAsync(tradingPair.ToString(TradingPairFormatOption), cancellationToken);
            if (!result.Success)
                throw new Exception(result.Message);
            
            return new Core.Models.Ticker(Name, tradingPair, Convert.ToDecimal(result.Result.Ask), Convert.ToDecimal(result.Result.Bid), Convert.ToDecimal(result.Result.Last));
        }
    }
}