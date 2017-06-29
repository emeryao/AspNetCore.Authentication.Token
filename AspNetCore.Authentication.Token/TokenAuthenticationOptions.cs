using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace AspNetCore.Authentication.Token
{
    public class TokenAuthenticationOptions : AuthenticationOptions, IOptions<TokenAuthenticationOptions>
    {
        TokenAuthenticationOptions IOptions<TokenAuthenticationOptions>.Value => this;

        public string AuthorizationHeaderScheme { get; set; } = "Bearer ";

        // Add whatever properties you want

        public TokenAuthenticationOptions()
        {
            AuthenticationScheme = "Automatic";
            AutomaticAuthenticate = true;
            AutomaticChallenge = true;
        }
    }
}
