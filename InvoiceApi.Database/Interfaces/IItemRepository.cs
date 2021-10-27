using InvoiceApi.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IItemRepository
    {
        Task Add(Item item);
        Task UpdateItem(Item item);
        Task Delete(int id);
        Task<List<Item>> GetAllItems();
        Task<List<Item>> GetFilteredItems(string name, string code, string account, decimal fromPrice, decimal toPrice, string measure);
    }
}
