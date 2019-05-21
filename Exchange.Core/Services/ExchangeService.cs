using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Core.ExchangeCases;
using Exchange.Infrastructure.Interfaces;
using Exchange.Core.Interfaces;

namespace Exchange.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly ICurrencyRateService _currencyRateService;
        
        public ExchangeService(ICurrencyRateService currencyRateService)
        {
            _currencyRateService = currencyRateService;
        }

        //TODO use currencies int this method instead of currencynames
        public decimal Exchange(string currencyIsoNameFrom, string currencyIsoNameTo, decimal amount)
        {
            //DKK
            var baseCurrency = _currencyRateService.GetBaseCurrency();

            var currencyFrom = _currencyRateService.GetCurrencyRate(currencyIsoNameFrom);
            var currencyTo = _currencyRateService.GetCurrencyRate(currencyIsoNameTo);
            
            IExchangeCase exchangeCase = new ExchangeCaseFactory().GetExchangeCase(currencyFrom, currencyTo, baseCurrency);

            return exchangeCase.Exchange(amount);
        }

    }
}
