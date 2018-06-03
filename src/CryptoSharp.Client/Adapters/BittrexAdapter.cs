using System;
using System.Threading;
using System.Threading.Tasks;
using CryptoSharp.Client.Exchanges.Bittrex;
using CryptoSharp.Client.Mappers;
using Cryptrend.Core.Exchange;
using CrypTrend.Adapter.Adapters;
using CrypTrend.Core.Models;

namespace CrypTrend.Client.Adapters
{
    public class BittrexAdapter : IExchangeAdapter
    {

        private readonly IBittrexClient _bittrexClient;
        private const TradingPairFormatOption _tradingPairFormatOption = TradingPairFormatOption.QuoteFirstDash;

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
            var result = await _bittrexClient.GetTickerAsync(tradingPair.ToString(_tradingPairFormatOption), cancellationToken);
            if (!result.Success)
                throw new Exception(result.Message);
            return result.Result.ToTicker(tradingPair, ExchangeName.Bittrex.Value);
        }
    }
}