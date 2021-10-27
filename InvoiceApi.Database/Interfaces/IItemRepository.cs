using InvoiceApi.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<List<Item>> GetAllItems();
        Task<List<Item>> GetFilteredItems(string name, string code, string account, decimal fromPrice, decimal toPrice, string measure);
    }
}
