using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Core.Model
{
    public class InputParamsForExchange
    {
        public string IsoCurrencyFrom { get; set; }
        public string IsoCurrencyTo { get; set; }
        public decimal Amount { get; set; }
    }
}
