﻿using Thinktecture.IdentityModel.Owin.ScopeValidation;

namespace Owin
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder RequireScopes(this IAppBuilder app, params string[] scopes)
        {
            var options = new ScopeValidationOptions
            {
                Scopes = scopes,

                AllowAnonymousAccess = false,
                ScopeClaimType = "scope"
            };

            app.RequireScopes(options);
            return app;
        }

        public static IAppBuilder RequireScopes(this IAppBuilder app, ScopeValidationOptions options)
        {
            app.Use(typeof(ScopeValidationMiddleware), options);
            return app;
        }
    }
}