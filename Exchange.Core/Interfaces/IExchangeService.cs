using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Interfaces
{
    public interface IExchangeService
    {
        decimal Exchange(string currencyIsoNameFrom, string currencyIsoNameTo, decimal amount);
    }
}
