using InvoiceApi.Common.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserDTO user);
        Task ConfirmEmailAsync(string email);
        Task Delete(string username);
        Task<UserDTO> FindByUsernameAsync(string username);
        Task<List<UserDTO>> GetAll();
        Task<bool> Login(UserDTO user);
        Task<bool> TryChangePasswordAsync(UserDTO user, string newPassword);
        Task UpdateRefreshToken(UserDTO user);
    }
}
