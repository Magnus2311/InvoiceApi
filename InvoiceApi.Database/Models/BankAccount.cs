using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class BankAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string IBAN { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
