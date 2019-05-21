using Exchange.Core.ExchangeCases;
using Exchange.Infrastructure.Model;
using NUnit.Framework;

namespace Exchange.Core.Tests.ExchangeCases
{
    [TestFixture]
    class CurrencyFromCurrencyToTheSameCaseTests
    {
        [Test]
        public void Exchange_ReturnsTheSameAmount_WhenFromAndToCurrenciesAreTheSame()
        {
            var currencyFrom = new CurrencyRate {IsoName = "EUR"};
            var currencyTo = new CurrencyRate { IsoName = "EUR" };
            var amount = 500M;
          
            var exchangeCase = new CurrencyFromCurrencyToTheSameCase(currencyFrom, currencyTo);

            Assert.AreEqual(amount, exchangeCase.Exchange(amount));
        }

    }


}