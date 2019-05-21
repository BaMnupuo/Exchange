using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;

namespace Exchange.Core.ExchangeCases
{
    public class ExchangeCaseFactory
    {
        //TODO refactor to Dictionary ?
        public IExchangeCase GetExchangeCase(CurrencyRate currencyFrom, CurrencyRate currencyTo, CurrencyRate baseCurrency)
        {
            if (currencyFrom.Equals(currencyTo))
            {
                return  new CurrencyFromCurrencyToTheSameCase(currencyFrom, currencyTo);
            }

            if (currencyFrom.Equals(baseCurrency))
            {
                return new CurrencyFromIsBaseCurrencyCase(currencyFrom, currencyTo);
            }

            if (currencyTo.Equals(baseCurrency))
            {
                return new CurrencyToIsBaseCurrencyCase(currencyFrom, currencyTo);
            }

            return new CurrencyFromAndCurrencyToAreNotBaseCase(currencyFrom, currencyTo);
        }
    }
}
