using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;
using Exchange.Core.Interfaces;
using Exchange.Infrastructure.Interfaces;

namespace Exchange.Services
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;
        private readonly string _baseCurrency = "DKK";

        public CurrencyRateService(ICurrencyRateRepository currencyRateRepository)
        {
            _currencyRateRepository = currencyRateRepository;
        }

        public CurrencyRate GetBaseCurrency()
        {
            return _currencyRateRepository.GetCurrencyRate(_baseCurrency);
        }

        public CurrencyRate GetCurrencyRate(string isoCode)
        {
            var currency = _currencyRateRepository.GetCurrencyRate(isoCode);

            if (currency == null)
            {
                var supportedCurrencies = _currencyRateRepository.GetCurrencies().Select(x => x.IsoName);
                throw new InvalidEnumArgumentException($"Currency code {isoCode} is unsupported. Supported currency codes: { string.Join(",", supportedCurrencies)}");
            }
          
            return currency;
        }
    }
}
