using Exchange.Infrastructure.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Core.Interfaces;
using Exchange.Infrastructure.Model;
using Moq;
using Exchange.Services;
using System.ComponentModel;

namespace Exchange.Core.Services.Tests
{
    [TestFixture]
    public class CurrencyRateServiceTests
    {

        [Test]
        public void GetBaseRate_ReturnsDKK_WhenCalled()
        {

            var repo = new Mock<ICurrencyRateRepository>();
            repo.Setup(x => x.GetCurrencyRate("DKK")).Returns(new CurrencyRate() {IsoName = "DKK"});

            var service = new CurrencyRateService(repo.Object);

            var result = service.GetBaseCurrency();

            Assert.IsNotNull(result);
            Assert.AreEqual("DKK",result.IsoName);

        }

        [Test]
        public void GetCurrencyRate_ThrowsError_WhenUnsupportedCurrencyGiven()
        {
            var repo = new Mock<ICurrencyRateRepository>();
            repo.Setup(x => x.GetCurrencies()).Returns(new List<CurrencyRate>{ new CurrencyRate() { IsoName = "DKK" }});
            repo.Setup(x => x.GetCurrencyRate("DKK")).Returns(new CurrencyRate() { IsoName = "DKK" });
            var service = new CurrencyRateService(repo.Object);

            Assert.Throws<InvalidEnumArgumentException>(() => service.GetCurrencyRate("DAK"));
        }
    }
}

