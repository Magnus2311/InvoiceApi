using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class MyCompanyBankAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string IBAN { get; set; }

        public int MyCompanyId { get; set; }
        public MyCompany MyCompany { get; set; }
    }
}
