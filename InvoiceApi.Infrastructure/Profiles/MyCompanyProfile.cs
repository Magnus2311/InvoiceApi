using AutoMapper;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;

namespace InvoiceApi.Infrastructure.Profiles
{
    public class MyCompanyProfile : Profile
    {
        public MyCompanyProfile()
        {
            CreateMap<MyCompanyDTO, MyCompany>();
            CreateMap<MyCompany, MyCompanyDTO>();

            CreateMap<MyCompanyAddressDTO, MyCompanyAddress>();
            CreateMap<MyCompanyAddress, MyCompanyAddressDTO>();

            CreateMap<MyCompanyBankAccountDTO, MyCompanyBankAccount>();
            CreateMap<MyCompanyBankAccount, MyCompanyBankAccountDTO>();
        }
    }
}
