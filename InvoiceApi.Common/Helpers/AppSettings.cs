using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceApi.Common.Helpers
{
    public static class AppSettings
    {
        public static string Secret { get; } = "AMGOYbZNFa5ru6IkghTu5QW8Qxp9UePRjCRe5mbq"; //Environment.GetEnvironmentVariable("JwtSecret", EnvironmentVariableTarget.Machine);
        public const string ValidIssuer = "https://localhost:5001/";
        public const string ValidAudience = "https://localhost:5001/";
    }
}
