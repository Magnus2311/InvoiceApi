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
        }
    }
}
