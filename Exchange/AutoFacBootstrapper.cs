using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Exchange.Core.Interfaces;
using Exchange.Infrastructure.Interfaces;
using Exchange.Infrastructure.Repository;
using Exchange.Services;

namespace Exchange
{
    public static class AutoFacBootstrapper
    {
        public static ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // repositories
            builder.RegisterType<CurrencyRateRepository>().As<ICurrencyRateRepository>();

            //services
            builder.RegisterType<InputValidationService>().As<IInputValidationService>();
            builder.RegisterType<CurrencyRateService>().As<ICurrencyRateService>();
            builder.RegisterType<ExchangeService>().As<IExchangeService>();

            return builder;
        }
    }
}
