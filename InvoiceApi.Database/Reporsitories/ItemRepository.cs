using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Models;

namespace InvoiceApi.Database.Reporsitories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
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
