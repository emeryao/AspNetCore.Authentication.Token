using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace AspNetCore.Authentication.Token
{
    public class TokenAuthenticationMiddleware : AuthenticationMiddleware<TokenAuthenticationOptions>
    {
        public TokenAuthenticationMiddleware(
            RequestDelegate next,
            IOptions<TokenAuthenticationOptions> options,
            ILoggerFactory loggerFactory,
            UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {
            // You can get the injected services here in the construction
        }

        protected override AuthenticationHandler<TokenAuthenticationOptions> CreateHandler() => new TokenAuthenticationHandler();
    }
}
