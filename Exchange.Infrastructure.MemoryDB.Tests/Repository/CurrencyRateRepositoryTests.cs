using Exchange.Infrastructure.Interfaces;
using Exchange.Infrastructure.Repository;
using NUnit.Framework;

namespace Exchange.Infrastructure.MemoryDB.Repository.Tests
{
    [TestFixture]
    public class CurrencyRateRepositoryTests
    {

        private ICurrencyRateRepository getRepository()
        {
            return new CurrencyRateRepository();
        }

        [Test]
        public void Repository_ReturnsHardcodedCurrencyRates_WhenGetCurrenciesCalled()
        {
            var result = getRepository().GetCurrencies();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);

        }

        [Test]
        public void Repository_ReturnsCurrencyRates_WhenIsoCodeGiven()
        {
            var result = getRepository().GetCurrencyRate("DKK");

            Assert.IsNotNull(result);
            Assert.AreEqual("Danish kroner", result.CurrencyName);

        }

        [Test]
        public void Repository_ReturnsNull_WhenWrongIsoCodeGiven()
        {
            var result = getRepository().GetCurrencyRate("DKA");

            Assert.IsNull(result);
        }

    }
}
