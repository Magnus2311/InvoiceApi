using InvoiceApi.Database.Models;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IMyCompanyRepository : IRepository<MyCompany>
    {
        Task<MyCompany> GetByUserId(string userId);
    }
}
