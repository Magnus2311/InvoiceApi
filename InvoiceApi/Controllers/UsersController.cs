using InvoiceApi.Common.Helpers;
using InvoiceApi.Common.Interfaces;
using InvoiceApi.Common.Models.Database;
using InvoiceApi.Helpers.Attributes;
using InvoiceApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvoiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenizer tokenizer;
        private readonly IEmailsService emailsService;

        public UsersController(IUserService _userService, 
            IEmailsService _emailsService,
            ITokenizer _tokenizer)
        {
            userService = _userService;
            emailsService = _emailsService;
            tokenizer = _tokenizer;
        }
        [HttpGet]
        public string Get()
        {
            return "Working";
        }

        [HttpPost("add")]
        public async Task Add(UserDTO user)
        {
            var token = tokenizer.CreateRegistrationToken(user.Username);
            await emailsService.SendRegistrationEmail(Request.Host.ToString(), user.Username, token, user.Template);
            await userService.AddUser(user);
        }

        [HttpDelete("delete")]
        public async Task Delete(string username)
            => await userService.Delete(username);

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            try
            {
                var isSuccessful = await userService.Login();
                if (isSuccessful)
                {
                    var token = tokenizer.GenerateUserJwtToken(GlobalHelpers.CurrentUser);
                    var refreshToken = tokenizer.GenerateUserJwtToken(GlobalHelpers.CurrentUser, true);
                    GlobalHelpers.CurrentUser.RefreshTokens.Add(refreshToken);
                    await userService.UpdateRefreshToken(GlobalHelpers.CurrentUser);
                    SetAccessTokenInCookie(token);
                    SetRefreshTokenInCookie(refreshToken);

                    return Ok(new AuthenticateResponse(GlobalHelpers.CurrentUser, token.ToString()));
                }
                return Unauthorized();
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpGet("getUsername")]
        [Authorize]
        public async Task<IActionResult> GetUserName() => Ok(await userService.FindByUsernameAsync(HttpContext.User.Identity.Name));

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var user = await userService.FindByUsernameAsync(HttpContext.User.Identity.Name);
            var refreshToken = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "refresh_token").Value;
            user.RefreshTokens.Remove(refreshToken);
            await userService.UpdateRefreshToken(user);
            HttpContext.Response.Cookies.Delete("access_token");
            HttpContext.Response.Cookies.Delete("refresh_token");
            return Ok();
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (!tokenizer.ValidateToken(token)) return BadRequest();

            var claims = tokenizer.DecodeToken(token).ToDictionary(x => x.Key, x => x.Value);
            var tempEmail = claims[ClaimTypes.Email];

            if (email.ToUpper() == tempEmail.ToUpper())
                await userService.ConfirmEmailAsync(email);
            else
                return BadRequest();

            return Ok();
        }

        [HttpPost("sendSecondaryConfirmationEmail")]
        public async Task SecondaryConfirmationEmail(UserDTO user)
        {   
            var token = tokenizer.CreateRegistrationToken(user.Username);
            await emailsService.SendRegistrationEmail(Request.Host.ToString(), user.Username, token, user.Template);
        }

        [HttpPost("sendResetPasswordEmail")]
        public async Task ResetPasswordEmail(UserDTO user)
        {
            var host = Request.Host.ToString();
            var token = tokenizer.CreateRegistrationToken(user.Username);
            await emailsService.SendResetPasswordEmail(Request.Host.ToString(), user.Username, token, user.Template);
        }

        [HttpGet("checkResetPassword")]
        public IActionResult CheckResetPasswordToken(string token)
        {
            if (!tokenizer.ValidateToken(token)) return BadRequest();

            var claims = tokenizer.DecodeToken(token).ToDictionary(x => x.Key, x => x.Value);
            var email = claims[ClaimTypes.Email];
            return Ok(email);
        }

        [HttpPost("changePassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePassParams passes)
        {
            GlobalHelpers.CurrentUser.Password = passes.OldPassword;
            if (await userService.Login())
                if (await userService.TryChangePasswordAsync(passes.NewPassword))
                    return Ok();

            return BadRequest();
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassParams passes)
        {
            if (!tokenizer.ValidateToken(passes.Token)) return BadRequest();

            var username = tokenizer.DecodeToken(passes.Token).ToDictionary(x => x.Key, x => x.Value)[ClaimTypes.Email];
            GlobalHelpers.CurrentUser = await userService.FindByUsernameAsync(username);
            if (await userService.TryChangePasswordAsync(passes.NewPassword))
                return Ok();

            return BadRequest();
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddYears(1),
            };
            Response.Cookies.Append("refresh_token", refreshToken, cookieOptions);
        }

        private void SetAccessTokenInCookie(string accessToken)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
            };
            Response.Cookies.Append("access_token", accessToken, cookieOptions);
        }

        public class ChangePassParams
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
        }

        public class ResetPassParams
        {
            public string Token { get; set; }
            public string NewPassword { get; set; }
        }
    }
}
