using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Core.Model;

namespace Exchange.Services
{
    public class InputValidationService : IInputValidationService
    {
        private readonly string _wrongParametersError = "Usage: Exchange <currency pair> <amount to exchange>" + Environment.NewLine + "As example: EUR/DKK 100 ";
        
        public InputParamsForExchange Validate(string[] args)
        {
            if (args == null)
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }

            if (args.Length != 2)
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }

            if (!decimal.TryParse(args[1], out var amount))
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }

            if (amount < 0)
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }

            var currencyPair = args[0];
            if (currencyPair.Split('/').Length != 2)
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }

            var currencyIsoFrom = currencyPair.Split('/')[0];
            if (string.IsNullOrEmpty(currencyIsoFrom))
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }
          
            var currencyIsoTo = currencyPair.Split('/')[1];
            if (string.IsNullOrEmpty(currencyIsoTo))
            {
                throw new InvalidEnumArgumentException(_wrongParametersError);
            }
         
            return new InputParamsForExchange()
            {
                IsoCurrencyFrom = currencyIsoFrom.ToUpper(),
                IsoCurrencyTo = currencyIsoTo.ToUpper(),
                Amount = amount
            };
        }
    }
}
