using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using System.Threading.Tasks;

namespace InvoiceApi.Services
{
    public class BulstatService : IBulstatService
    {
        public async Task<MyCompanyDTO> SearchByBulstat(string bulstat)
        {
            //TO DO: Имплементация на сървис за търсене по булстат
            return new();
        }
    }
}
