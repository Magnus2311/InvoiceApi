using InvoiceApi.Database.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class MyCompany : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Bulstat { get; set; }
        public string VatNumber { get; set; }
        public string Manager { get; set; }

        public List<MyCompanyAddress> Addresses { get; set; } = new();
        public List<MyCompanyBankAccount> BankAccounts { get; set; } = new();

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
