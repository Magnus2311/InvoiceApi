using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Reporsitories
{
    public class ItemRepository : IItemRepository
    {
        public async Task Add(Item item)
        {
            var context = new InvoiceDbContext();
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            var dbContext = new InvoiceDbContext();
            var itemToUpdate = await dbContext.Items.FirstOrDefaultAsync(p => p.Id == item.Id);
            itemToUpdate = item;
            await dbContext.SaveChangesAsync();
        }

        public void Delete (int id)
        {
            var context = new InvoiceDbContext();
            var itemDb = context.Items.FirstOrDefault(i => i.Id == id);
            context.Remove(itemDb);
        }

        public async Task<List<Item>> GetAllItems()
        {
            var dbContext = new InvoiceDbContext();
            return await dbContext.Items.ToListAsync();
        }

        public async Task<List<Item>> GetFilteredItems(string name, string code, string account, decimal fromPrice, decimal toPrice, string measure)
        {
            var dbContext = new InvoiceDbContext();
            return await dbContext.Items.Where(i => (string.IsNullOrEmpty(name) || i.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()))
                                              && (string.IsNullOrEmpty(code) || i.Code.ToLowerInvariant().Contains(code.ToLowerInvariant()))
                                              && (string.IsNullOrEmpty(account) || i.Account.Contains(account))
                                              && i.Price >= fromPrice && (toPrice == 0 || i.Price <= toPrice)
                                              && (string.IsNullOrEmpty(measure) || i.Measure.ToLowerInvariant().Contains(measure.ToLowerInvariant()))
                                         ).ToListAsync();
        }
    }
}
