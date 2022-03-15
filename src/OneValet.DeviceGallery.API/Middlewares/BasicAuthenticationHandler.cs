using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using OneValet.DeviceGallery.Application.DTOs.User;
using OneValet.DeviceGallery.Application.Interfaces.Services;
using OneValet.DeviceGallery.Application.Wrappers;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace OneValet.DeviceGallery.API.Middlewares
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        //private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            //,
            //IUserService userService
            )
            : base(options, logger, encoder, clock)
        {
            //_userService = userService;
        }


        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.Substring("Basic ".Length).Trim();
                System.Console.WriteLine(token);
                var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var credentials = credentialstring.Split(':');
                if (credentials[0] == "admin" && credentials[1] == "admin")
                {
                    var claims = new[] { new Claim("name", credentials[0]), new Claim(ClaimTypes.Role, "Admin") };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    var claimsPrincipal = new ClaimsPrincipal(identity);
                    return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
                }

                Response.StatusCode = 401;
                Response.Headers.Add("WWW-Authenticate", "Basic realm=\"dotnetthoughts.net\"");
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
            else
            {
                string realm = "dotnetthoughts";
                Response.StatusCode = 401;
                //Response.Headers.Add("WWW-Authenticate", "Basic realm=\"dotnetthoughts.net\"");
                Response.Headers.Add("WWW-Authenticate",
    string.Format("Basic realm=\"{0}\"", realm));
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
            return base.HandleChallengeAsync(properties);
        }
    }
}
