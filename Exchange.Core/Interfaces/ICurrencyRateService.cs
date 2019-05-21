using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;

namespace Exchange.Core.Interfaces
{
    public interface ICurrencyRateService
    {
        CurrencyRate GetBaseCurrency();
        CurrencyRate GetCurrencyRate(string isoCode);
    }
}
