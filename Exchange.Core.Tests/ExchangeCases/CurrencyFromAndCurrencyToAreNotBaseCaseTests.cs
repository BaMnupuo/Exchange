using Exchange.Core.ExchangeCases;
using Exchange.Infrastructure.Model;
using NUnit.Framework;

namespace Exchange.Core.Tests.ExchangeCases
{
    [TestFixture]
    class CurrencyFromAndCurrencyToAreNotBaseCaseTests
    {
        [Test]
        public void Exchange_ReturnsCalculatedAmount_WhenCurrencyFromAndCurrencyToAreNotBaseCase()
        {
            var currencyTo = new CurrencyRate {IsoName = "USD",AmountInBaseCurrency = 100, AmountInLocalCurrency = 663.11M };
            var currencyFrom = new CurrencyRate { IsoName = "EUR", AmountInBaseCurrency = 100, AmountInLocalCurrency = 743.94M
            };
            var amount = 500M;
          
            var exchangeCase = new CurrencyFromAndCurrencyToAreNotBaseCase(currencyFrom, currencyTo);

            Assert.AreEqual(560.9477M, exchangeCase.Exchange(amount));
        }

    }


}
