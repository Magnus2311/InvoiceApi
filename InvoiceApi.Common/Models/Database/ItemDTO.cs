using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Models.Database
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Measure { get; set; }
        public decimal Price { get; set; }
        public string Account { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
