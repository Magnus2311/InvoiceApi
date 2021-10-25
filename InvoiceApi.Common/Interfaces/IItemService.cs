using InvoiceApi.Common.Models.Database;
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
    }
}
