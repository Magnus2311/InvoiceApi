using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Interfaces
{
    public interface IEmailsService
    {
        Task SendRegistrationEmail(string url, string email, string token, string template);
        Task ReSendRegistrationEmail(string url, string email, string token);
        Task SendResetPasswordEmail(string url, string email, string token, string template);
    }
}