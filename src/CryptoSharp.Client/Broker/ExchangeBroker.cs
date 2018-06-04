using System.Collections.Generic;
using CrypTrend.Adapter.Adapters;

namespace CrypTrend.Client.Broker
{
    public class ExchangeBroker
    {

        private IEnumerable<IExchangeAdapter> _adapters;

        public ExchangeBroker(IEnumerable<IExchangeAdapter> adapters)
        {
            _adapters = adapters;
        }


    }
}