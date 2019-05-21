using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange.Infrastructure.Model;

namespace Exchange.Infrastructure.Interfaces
{
    public interface ICurrencyRateRepository
    {
      
        CurrencyRate GetCurrencyRate(string isoName);

        ICollection<CurrencyRate> GetCurrencies();
    }
}
