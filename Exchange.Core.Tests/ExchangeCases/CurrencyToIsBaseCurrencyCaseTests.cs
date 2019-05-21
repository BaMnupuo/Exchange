using Exchange.Core.ExchangeCases;
using Exchange.Infrastructure.Model;
using NUnit.Framework;

namespace Exchange.Core.Tests.ExchangeCases
{
    [TestFixture]
    class CurrencyToIsBaseCurrencyCaseTests
    {
        [Test]
        public void Exchange_ReturnsCalculatedAmount_WhenToIsBaseCurrency()
        {
            var currencyTo = new CurrencyRate {IsoName = "DKK",AmountInBaseCurrency = 100, AmountInLocalCurrency = 100};
            var currencyFrom = new CurrencyRate { IsoName = "EUR", AmountInBaseCurrency = 100, AmountInLocalCurrency = 743.94M
            };
            var amount = 500M;
          
            var exchangeCase = new CurrencyToIsBaseCurrencyCase(currencyFrom, currencyTo);

            Assert.AreEqual(3719.7M, exchangeCase.Exchange(amount));
        }

    }


}
