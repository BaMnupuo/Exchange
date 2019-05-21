using System;
using Autofac;
using Exchange.Core.Interfaces;
using Exchange.Services;

namespace Exchange
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var container = ConfigureContainer();

                var validator =  container.Resolve<IInputValidationService>();
                var service = container.Resolve<IExchangeService>();

                var inputParams = validator.Validate(args);
                var result = service.Exchange(inputParams.IsoCurrencyFrom, inputParams.IsoCurrencyTo,inputParams.Amount);

                Console.WriteLine(result.ToString("0.####"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static IContainer ConfigureContainer()
        {
            var builder = AutoFacBootstrapper.ConfigureContainer();
            return builder.Build();
        }
    }
}
