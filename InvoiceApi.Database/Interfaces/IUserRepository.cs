using InvoiceApi.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task ConfirmEmailAsync(string email);
        Task Delete(string username);
        Task<User> FindByUsernameAsync(string username);
        Task<bool> TryChangePasswordAsync(User user, string newPassword);
        Task<List<User>> GetAll();
        Task<bool> Login(User user);
        Task UpdateRefreshToken(User user);
    }
}
