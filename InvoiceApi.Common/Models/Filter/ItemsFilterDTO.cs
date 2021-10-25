using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Models.Filter
{
    public class ItemsFilterDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Measure { get; set; }
        public string Account { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
    }
}
