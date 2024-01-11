using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceExchange.Models
{
    public class currencyExchangeRate
    {
        public decimal ExchangeRate { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime ValidToDate { get; set; }
    }
}
