using InvoiceApi.Common.Models.Database;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IBulstatService
    {
        Task<MyCompanyDTO> SearchByBulstat(string bulstat);
    }
}
