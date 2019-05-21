using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;

namespace Exchange.Core.ExchangeCases
{
    public class CurrencyToIsBaseCurrencyCase : IExchangeCase
    {
        private CurrencyRate _currencyFrom;
        private CurrencyRate _currencyTo;

        public CurrencyToIsBaseCurrencyCase(CurrencyRate currencyFrom, CurrencyRate currencyTo)
        {
            _currencyFrom = currencyFrom;
            _currencyTo = currencyTo;
        }
        public decimal Exchange(decimal amount)
        {
            return decimal.Round(amount / _currencyTo.AmountInBaseCurrency * _currencyFrom.AmountInLocalCurrency, 4);
        }
    }
}
