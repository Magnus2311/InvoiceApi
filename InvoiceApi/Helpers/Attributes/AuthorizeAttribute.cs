using InvoiceApi.Common.Helpers;
using InvoiceApi.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceApi.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private AuthorizationFilterContext _context;
        private string accessSecToken;

        public AuthorizeAttribute()
        {
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var services = context.HttpContext.RequestServices;
            var userService = services.GetService<IUserService>();
            var tokenizer = services.GetService<ITokenizer>();
            var handler = new JwtSecurityTokenHandler();
            _context = context;
            if (context.HttpContext.Request.Cookies.TryGetValue("access_token", out string accessToken)
                && await ValidateToken(accessToken, userService, tokenizer)) return;

            if (context.HttpContext.Request.Cookies.TryGetValue("refresh_token", out string token)
                && await ValidateToken(token, userService, tokenizer))
            {
                var username = (handler.ReadToken(token) as JwtSecurityToken).Claims.FirstOrDefault(claim => claim.Type.Contains("name")).Value;
                var user = await userService.FindByUsernameAsync(username);
                if (user != null && user.RefreshTokens.Any(rt => rt == token))
                {
                    accessSecToken = tokenizer.GenerateUserJwtToken(user);
                    SetAccessToken(accessSecToken, context);
                    return;
                }
            }

            context.Result = new UnauthorizedResult();
        }

        private async Task<bool> ValidateToken(string authToken, IUserService userService, ITokenizer tokenizer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = tokenizer.GetValidationParameters();

            try
            {
                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                _context.HttpContext.User = (ClaimsPrincipal)principal;
                var user = await userService.FindByUsernameAsync(_context.HttpContext.User.Identity.Name);
                GlobalHelpers.CurrentUser = user;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void SetAccessToken(string accessToken, AuthorizationFilterContext context)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
            };
            context.HttpContext.Response.Cookies.Append("access_token", accessToken, cookieOptions);
        }
    }
}
