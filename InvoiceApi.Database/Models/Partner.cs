using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Models
{
    public class Partner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsVat { get; set; }
        public string EIK { get; set; }
        public string VatNumber { get; set; }
        public string ContactName { get; set; }
        public string NameInOtherLanguage { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
