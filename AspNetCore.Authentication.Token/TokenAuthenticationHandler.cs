using Microsoft.AspNetCore.Authentication;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCore.Authentication.Token
{
    public class TokenAuthenticationHandler : AuthenticationHandler<TokenAuthenticationOptions>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            await Task.FromResult(0);

            string authorization = Request.Headers["Authorization"];
            string token = "";

            if (string.IsNullOrEmpty(authorization))
                return AuthenticateResult.Fail("no Authorization in request header");

            if (authorization.StartsWith(Options.AuthorizationHeaderScheme, StringComparison.OrdinalIgnoreCase))
                token = authorization.Substring(Options.AuthorizationHeaderScheme.Length).Trim();

            if (string.IsNullOrEmpty(token))
                return AuthenticateResult.Fail("no Authorization in request header");

            // DO whatever you want with the `token` and get user info to fill the `claims` as you need

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "UserId"),
                new Claim(ClaimTypes.Name, "UserName"),
                new Claim(ClaimTypes.Role, "UserRole"),
            };

            AuthenticationTicket ticket = new AuthenticationTicket(new ClaimsPrincipal(new ClaimsIdentity(claims, Options.AuthenticationScheme)), new Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties(), Options.AuthenticationScheme);
            return AuthenticateResult.Success(ticket);
        }
    }
}
