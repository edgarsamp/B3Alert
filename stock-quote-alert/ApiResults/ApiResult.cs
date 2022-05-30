using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.ApiResults
{
    internal class ApiResult
    {
        public List<ApiStock> results { get; set; }
        public DateTime requestedAt { get; set; }
    }
}
