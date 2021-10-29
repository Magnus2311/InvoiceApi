using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Models.Database
{
    public class PartnerDTO
    {
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
