using System.Threading;
using System.Threading.Tasks;
using CrypTrend.Core.Models;

namespace CrypTrend.Adapter.Adapters
{
    public interface IExchangeAdapter
    {

        /// <summary>
        /// Gets the current tick values for a trading pair.
        /// </summary>
        /// <param name="tradingPair">A trading pair <see cref="TradingPair"/></param>
        /// <returns>A ticker <see cref="Ticker"/></returns>
        Task<Ticker> GetTickerAsync(TradingPair tradingPair);

        /// <summary>
        /// Gets the current tick values for a trading pair.
        /// </summary>
        /// <param name="tradingPair">A trading pair <see cref="TradingPair"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A ticker <see cref="Ticker"/></returns>
        Task<Ticker> GetTickerAsync(TradingPair tradingPair, CancellationToken cancellationToken);

    }
}