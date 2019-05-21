using Exchange.Core.ExchangeCases;
using Exchange.Infrastructure.Model;
using NUnit.Framework;

namespace Exchange.Core.Tests.ExchangeCases
{
    [TestFixture]
    class ExchangeCaseFactoryTests
    {
        [Test]
        public void GetCase_ReturnsCurrencyFromCurrencyToTheSameCase_WhenFromAndToCurrenciesAreEqual()
        {
            var currencyFrom = new CurrencyRate {IsoName = "EUR"};
            var currencyTo = new CurrencyRate { IsoName = "EUR" };
            var currencyBase = new CurrencyRate { IsoName = "DKK" };
            var factory = new ExchangeCaseFactory();

            var result = factory.GetExchangeCase(currencyFrom, currencyTo, currencyBase);

            Assert.IsInstanceOf<CurrencyFromCurrencyToTheSameCase>(result);
        }

        [Test]
        public void GetCase_ReturnsCurrencyFromIsBaseCurrencyCase_WhenFromIsBaseCurrency()
        {
            var currencyFrom = new CurrencyRate { IsoName = "DKK" };
            var currencyTo = new CurrencyRate { IsoName = "EUR" };
            var currencyBase = new CurrencyRate { IsoName = "DKK" };
            var factory = new ExchangeCaseFactory();

            var result = factory.GetExchangeCase(currencyFrom, currencyTo, currencyBase);

            Assert.IsInstanceOf<CurrencyFromIsBaseCurrencyCase>(result);
        }

        [Test]
        public void GetCase_ReturnsCurrencyToIsBaseCurrencyCase_WhenToIsBaseCurrency()
        {
            var currencyFrom = new CurrencyRate { IsoName = "EUR" };
            var currencyTo = new CurrencyRate { IsoName = "DKK" };
            var currencyBase = new CurrencyRate { IsoName = "DKK" };
            var factory = new ExchangeCaseFactory();

            var result = factory.GetExchangeCase(currencyFrom, currencyTo, currencyBase);

            Assert.IsInstanceOf<CurrencyToIsBaseCurrencyCase>(result);
        }



        [Test]
        public void GetCase_ReturnsCurrencyFromAndCurrencyToAreNotBaseCase_WhenToAndFromCurrenciesAreNotBase()
        {
            var currencyFrom = new CurrencyRate { IsoName = "EUR" };
            var currencyTo = new CurrencyRate { IsoName = "USD" };
            var currencyBase = new CurrencyRate { IsoName = "DKK" };
            var factory = new ExchangeCaseFactory();

            var result = factory.GetExchangeCase(currencyFrom, currencyTo, currencyBase);

            Assert.IsInstanceOf<CurrencyFromAndCurrencyToAreNotBaseCase>(result);
        }
    }


}