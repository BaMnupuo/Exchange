using Exchange.Core.ExchangeCases;
using Exchange.Infrastructure.Model;
using NUnit.Framework;

namespace Exchange.Core.Tests.ExchangeCases
{
    [TestFixture]
    class CurrencyFromIsBaseCurrencyCaseTests
    {
        [Test]
        public void Exchange_ReturnsCalculatedAmount_WhenFromIsBaseCurrency()
        {
            var currencyFrom = new CurrencyRate {IsoName = "DKK",AmountInBaseCurrency = 100, AmountInLocalCurrency = 100};
            var currencyTo = new CurrencyRate { IsoName = "EUR", AmountInBaseCurrency = 100, AmountInLocalCurrency = 743.94M
            };
            var amount = 500M;
          
            var exchangeCase = new CurrencyFromIsBaseCurrencyCase(currencyFrom, currencyTo);

            Assert.AreEqual(67.2097M, exchangeCase.Exchange(amount));
        }

    }


}
