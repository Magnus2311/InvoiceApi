using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Reporsitories
{
    public class MyCompanyRepository : BaseRepository<MyCompany>, IMyCompanyRepository
    {
        public async Task<MyCompany> GetByUserId(string userId)
        {
            var context = new InvoiceDbContext();
            return await context.MyCompanies
                .Include(mc => mc.Addresses)
                .Include(mc => mc.BankAccounts)
                .SingleOrDefaultAsync(c => c.UserId == userId);
        }

        public new async Task AddOrUpdate(MyCompany myCompany)
        {
            var context = new InvoiceDbContext();
            if (myCompany.Id != 0) await Update(myCompany);
            else await Add(myCompany);
            await context.SaveChangesAsync();
        }

        public new async Task Update(MyCompany myCompany)
        {
            var context = new InvoiceDbContext();
            var currentCompany = await context.MyCompanies
                .Include(mc => mc.BankAccounts)
                .Include(mc => mc.Addresses)
                .FirstOrDefaultAsync(mc => mc.Id == myCompany.Id);

            // Това не знам как може да стане по-добре, защото
            // не искат да се сетнат, ако се сетне само myCompany
            currentCompany.Addresses = myCompany.Addresses;
            currentCompany.BankAccounts = myCompany.BankAccounts;
            await context.SaveChangesAsync();
        }
    }
}
