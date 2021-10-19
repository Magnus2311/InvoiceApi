using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Reporsitories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public async Task Add(TEntity entity)
        {
            var context = new InvoiceDbContext();
            context.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddOrUpdate(TEntity entity)
        {
            var context = new InvoiceDbContext();
            if (entity.Id != 0) await Update(entity);
            else await Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var context = new InvoiceDbContext();
            var entity = await context.FindAsync<TEntity>(id);
            context.Remove(entity);
        }

        public async Task<TEntity> Get(string id)
        {
            return await new InvoiceDbContext().FindAsync<TEntity>(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return new InvoiceDbContext().Set<TEntity>();
        }

        public async Task Update(TEntity entity)
        {
            var context = new InvoiceDbContext();
            context.Entry(await context.FindAsync<TEntity>(entity.Id)).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }
    }
}
