using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.Quote
{
    internal abstract class Stock
    {
        public string Name;

        public Stock(string name)
        {
            Name = name.ToLower();
        }
    }
}
