using InvoiceApi.Common.Models.Database;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface ITokenizer
    {
        string CreateRegistrationToken(string email);
        IEnumerable<KeyValuePair<string, string>> DecodeToken(string token);
        string GenerateUserJwtToken(UserDTO user, bool isRefreshToken = false);
        TokenValidationParameters GetValidationParameters();
        bool ValidateToken(string token);
    }
}