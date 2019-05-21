using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.ExchangeCases
{
    public interface IExchangeCase
    {
        decimal Exchange(decimal amount);
    }
}
