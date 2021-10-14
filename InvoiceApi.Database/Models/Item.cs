using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
