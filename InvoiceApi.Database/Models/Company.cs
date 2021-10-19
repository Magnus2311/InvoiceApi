using InvoiceApi.Database.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApi.Database.Models
{
    public class Company : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Bulstat { get; set; }
        public string VatNumber { get; set; }
        public string Manager { get; set; }

        public List<Addres> Addresses { get; set; } = new();
        public List<BankAccount> BankAccounts { get; set; } = new();

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
