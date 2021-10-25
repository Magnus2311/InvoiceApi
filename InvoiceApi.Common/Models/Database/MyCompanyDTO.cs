using System.Collections.Generic;

namespace InvoiceApi.Common.Models.Database
{
    public class MyCompanyDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Bulstat { get; set; }
        public string VatNumber { get; set; }
        public string Manager { get; set; }

        public List<MyCompanyAddressDTO> Addresses { get; set; } = new();
        public List<MyCompanyBankAccountDTO> BankAccounts { get; set; } = new();
    }
}
