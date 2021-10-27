using InvoiceApi.Common.Models.Database;
using InvoiceApi.Common.Models.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IItemService
    {
        Task Add(ItemDTO item);
        Task Update(ItemDTO item);
        Task Delete(int id);

        Task<IEnumerable<ItemDTO>> GetAllItemsAsync();
        Task<List<ItemDTO>> GetFilteredItemsAsync(ItemsFilterDTO filter);

    }
}
