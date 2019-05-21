using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;

namespace Exchange.Core.ExchangeCases
{
    public class CurrencyFromIsBaseCurrencyCase : IExchangeCase
    {

        private CurrencyRate _currencyFrom;
        private CurrencyRate _currencyTo;

        public CurrencyFromIsBaseCurrencyCase(CurrencyRate currencyFrom, CurrencyRate currencyTo)
        {
            _currencyFrom = currencyFrom;
            _currencyTo = currencyTo;
        }
        public decimal Exchange(decimal amount)
        {
            return decimal.Round(amount / _currencyTo.AmountInLocalCurrency * _currencyFrom.AmountInBaseCurrency, 4);
        }
    }
}
