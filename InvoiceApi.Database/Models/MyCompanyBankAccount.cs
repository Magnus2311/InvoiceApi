using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class MyCompanyBankAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string IBAN { get; set; }

        public int CompanyId { get; set; }
        public MyCompany Company { get; set; }
    }
}
