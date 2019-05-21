using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Infrastructure.Model
{
    public class CurrencyRate
    {
        public string CurrencyName { get; set; }
        public string IsoName { get; set; }
        public decimal AmountInBaseCurrency { get; set; }

        public decimal AmountInLocalCurrency { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                CurrencyRate cr = (CurrencyRate)obj;
                return (IsoName == cr.IsoName) && (CurrencyName == cr.CurrencyName) && (AmountInBaseCurrency == cr.AmountInBaseCurrency) && (AmountInLocalCurrency == cr.AmountInLocalCurrency);
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1271619648;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CurrencyName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IsoName);
            hashCode = hashCode * -1521134295 + AmountInBaseCurrency.GetHashCode();
            hashCode = hashCode * -1521134295 + AmountInLocalCurrency.GetHashCode();
            return hashCode;
        }
    }
}
