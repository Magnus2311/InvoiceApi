using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Database.Interfaces
{
    public interface IHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string savedPasswordHash, string currentPassowrd);
    }
}