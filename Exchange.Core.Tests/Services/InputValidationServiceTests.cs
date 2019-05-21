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
    public class InputValidationServiceTests
    {

        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenNoArgsGiven()
        {
            string[] args = null;
            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }

        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenWrongNumberOfArgs()
        {
            string[] args = {"aaa", "bbb", "ccc"};
            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }


        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenAmountIsNotNumber()
        {
            string[] args = { "aaa/bbb", "bbb"};
            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }

        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenAmountIsNegative()
        {
            string[] args = { "aaa/bbb", "-100" };
            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }

        [Test]
        public void Validate_ReturnsParsedAmount_WhenAmountIsPositive()
        {
            string[] args = { "EUR/USD", "100" };
            Assert.AreEqual(100M,new InputValidationService().Validate(args).Amount);
        }

        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenCurrencyPairCannotBeProcessed()
        {

            var service = new InputValidationService();
            string[] args = { "aaa&bbb", "100" };

            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }


        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenCurrencyFromNotSet()
        {

            var service = new InputValidationService();
            string[] args = { "/bbb", "100" };

            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }

        [Test]
        public void Validate_ReturnsParsedCurrencyFrom_WhenIsSet()
        {
            string[] args = { "EUR/xxx", "100" };
            Assert.AreEqual("EUR", new InputValidationService().Validate(args).IsoCurrencyFrom);
        }

        [Test]
        public void Validate_ThrowsInvalidEnumArgumentException_WhenCurrencyToNotSet()
        {

            var service = new InputValidationService();
            string[] args = { "bbb/", "100" };

            Assert.Throws<InvalidEnumArgumentException>(() => new InputValidationService().Validate(args));
        }

        [Test]
        public void Validate_ReturnsParsedCurrencyTo_WhenIsSet()
        {
            string[] args = { "xxx/YPN", "100" };
            Assert.AreEqual("YPN", new InputValidationService().Validate(args).IsoCurrencyTo);
        }
    }
}

