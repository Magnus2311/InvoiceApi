namespace InvoiceApi.Common.Models.Database
{
    public class BankAccountDTO
    {
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string IBAN { get; set; }
    }
}
