using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;

namespace Exchange.Core.ExchangeCases
{
    public class CurrencyFromAndCurrencyToAreNotBaseCase : IExchangeCase
    {
        private CurrencyRate _currencyFrom;
        private CurrencyRate _currencyTo;

        public CurrencyFromAndCurrencyToAreNotBaseCase(CurrencyRate currencyFrom, CurrencyRate currencyTo)
        {
            _currencyFrom = currencyFrom;
            _currencyTo = currencyTo;
        }
        public decimal Exchange(decimal amount)
        {
            return new CurrencyFromIsBaseCurrencyCase(_currencyFrom, _currencyTo).Exchange(new CurrencyToIsBaseCurrencyCase(_currencyFrom, _currencyTo).Exchange(amount));
        }
    }
}
