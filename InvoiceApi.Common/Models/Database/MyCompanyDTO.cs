using System.Collections.Generic;

namespace InvoiceApi.Common.Models.Database
{
    public class MyCompanyDTO
    {
        public string CompanyName { get; set; }
        public string Bulstat { get; set; }
        public string VatNumber { get; set; }
        public string Manager { get; set; }

        public List<MyCompanyAddressDTO> Addresses { get; set; } = new();
        public List<MyCompanyBankAccountDTO> BankAccountsDTO { get; set; } = new();
    }
}
