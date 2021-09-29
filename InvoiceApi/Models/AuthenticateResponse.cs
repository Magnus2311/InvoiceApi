using InvoiceApi.Common.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InvoiceApi.Models
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public bool IsConfirmed { get; set; }
        public string Username { get; set; }
        [JsonPropertyName("access_token")]
        public string Token { get; set; }


        public AuthenticateResponse(UserDTO user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            IsConfirmed = user.IsConfirmed;
            Token = token;
        }
    }
}
