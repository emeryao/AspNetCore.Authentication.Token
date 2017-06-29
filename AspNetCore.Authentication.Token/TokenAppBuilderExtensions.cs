using AspNetCore.Authentication.Token;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class TokenAppBuilderExtensions
    {
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<TokenAuthenticationMiddleware>();
        }

        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder app, TokenAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return app.UseMiddleware<TokenAuthenticationMiddleware>(Options.Create(options));
        }

    }
}
