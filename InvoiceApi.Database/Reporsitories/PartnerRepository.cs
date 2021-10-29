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
    public class PartnerRepository : IPartnerRepository
    {
        public async Task Add(Partner partner)
        {
            var context = new InvoiceDbContext();
            await context.Partners.AddAsync(partner);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePartner(Partner partner)
        {
            var dbContext = new InvoiceDbContext();
            var partnerToUpdate = await dbContext.Partners.FirstOrDefaultAsync(p => p.Id == partner.Id);
            partnerToUpdate = partner;
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var context = new InvoiceDbContext();
            var partnerDb = context.Partners.FirstOrDefault(i => i.Id == id);
            context.Remove(partnerDb);
            await context.SaveChangesAsync();
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            var dbContext = new InvoiceDbContext();
            return await dbContext.Partners.ToListAsync();
        }
    }
}
