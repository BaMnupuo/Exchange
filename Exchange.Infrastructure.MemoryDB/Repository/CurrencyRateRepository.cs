using System.Collections.Generic;
using System.Linq;
using Exchange.Infrastructure.Interfaces;
using Exchange.Infrastructure.Model;

namespace Exchange.Infrastructure.Repository
{
    public class CurrencyRateRepository : ICurrencyRateRepository

    {

        private IList<CurrencyRate> _currencyRates = new List<CurrencyRate>();
     

        public CurrencyRateRepository()
        {
            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 100,
                    CurrencyName = "Danish kroner",
                    IsoName = "DKK"
                }
            );

            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 743.94M,
                    CurrencyName = "Euro",
                    IsoName = "EUR"

                }
            );

            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 663.11M,
                    CurrencyName = "Amerikanske dollar",
                    IsoName = "USD"

                }
            );

            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 852.85M,
                    CurrencyName = "Britske pund",
                    IsoName = "GPB"

                }
            );

            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 76.10M,
                    CurrencyName = "Svenske kroner",
                    IsoName = "SEK"

                }
            );

            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 78.40M,
                    CurrencyName = "Norske kroner",
                    IsoName = "NOK"

                }
            );


            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 683.58M,
                    CurrencyName = "Schweiziske franck",
                    IsoName = "CHF"

                }
            );

            _currencyRates.Add(new CurrencyRate
                {
                    AmountInBaseCurrency = 100,
                    AmountInLocalCurrency = 683.58M,
                    CurrencyName = "Japanske yen",
                    IsoName = "JPY"

                }
            );

        }

        public CurrencyRate GetCurrencyRate(string isoName)
        {
            return _currencyRates.Where(x => x.IsoName == isoName).FirstOrDefault();
        }

        public ICollection<CurrencyRate> GetCurrencies()
        {
            return _currencyRates;
        }
    }
}
