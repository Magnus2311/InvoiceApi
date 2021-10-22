using InvoiceApi.Database.Interfaces;
using InvoiceApi.Database.Models;
using InvoiceApi.Database.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Reporsitories
{
    public class UserRepository : IUserRepository
    {
        // TO DO BaseRepository
        private readonly IHashService _hasher;

        public UserRepository()
        {
            _hasher = new HashService();
        }

        public async Task Add(User user)
        {
            var context = new InvoiceDbContext();
            user.Password = _hasher.HashPassword(user.Password);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
        public async Task ConfirmEmailAsync(string email)
        {
            var context = new InvoiceDbContext();
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username.ToUpper() == email.ToUpper());
            user.IsConfirmed = true;
            await context.SaveChangesAsync();
        }

        public async Task Delete(string username)
        {
            var context = new InvoiceDbContext();
            var dbUser = await FindByUsernameAsync(username);
            context.Users.Remove(dbUser);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            var context = new InvoiceDbContext();
            return await context.Users.FirstOrDefaultAsync(u => u.Username.ToUpper() == username.ToUpper());
        }

        public async Task<List<User>> GetAll()
        {
            var context = new InvoiceDbContext();
            return await context.Users.ToListAsync();
        }

        public async Task<bool> Login(User user)
        {
            var dbUser = await FindByUsernameAsync(user.Username);
            return _hasher.VerifyPassword(dbUser.Password, user.Password) && dbUser.IsConfirmed;

        }

        public async Task<bool> TryChangePasswordAsync(User user, string newPassword)
        {
            var context = new InvoiceDbContext();
            var dbUser = await context.Users
                .FirstOrDefaultAsync(u => u.Username.ToUpper() == user.Username.ToUpper());
            dbUser.Password = _hasher.HashPassword(newPassword);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateRefreshToken(User user)
        {
            var context = new InvoiceDbContext();
            var dbUser = await FindByUsernameAsync(user.Username);
            context.Update(dbUser);
            dbUser.RefreshTokensStr = JsonConvert.SerializeObject(user.RefreshTokens);
            context.Update(dbUser);
            await context.SaveChangesAsync();
        }
    }
}
