using InvoiceApi.Common.Models.Database;
using InvoiceApi.Database.Models;

namespace InvoiceApi.Common.Interfaces.Mappers
{
    public interface IMapMyCompanyService
    {
        MyCompany MapMyCompanyDTO(MyCompanyDTO myCompanyDTO);
        MyCompanyDTO MapMyCompanyToDTO(MyCompany myCompany);
    }
}
