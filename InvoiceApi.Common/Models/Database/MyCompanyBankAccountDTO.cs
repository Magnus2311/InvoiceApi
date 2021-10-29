namespace InvoiceApi.Common.Models.Database
{
    public class MyCompanyBankAccountDTO
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string IBAN { get; set; }
    }
}
