using InvoiceApi.Common.Models.Database;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IMyCompanyService
    {
        Task Update(MyCompanyDTO companyDTO);
        Task<MyCompanyDTO> Get();
    }
}
