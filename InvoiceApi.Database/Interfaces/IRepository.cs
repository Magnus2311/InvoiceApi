using InvoiceApi.Database.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        Task<T> Get(string id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(string id);
        Task AddOrUpdate(T Entity);
    }
}
