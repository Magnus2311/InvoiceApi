using System.Collections.Generic;

namespace InvoiceApi.Common.Models.Database
{
    public class CompanyDTO
    {
        public string CompanyName { get; set; }
        public string Bulstat { get; set; }
        public string VatNumber { get; set; }
        public string Manager { get; set; }

        public List<AddressDTO> Addresses { get; set; } = new();
        public List<BankAccountDTO> BankAccountsDTO { get; set; } = new();
    }
}
