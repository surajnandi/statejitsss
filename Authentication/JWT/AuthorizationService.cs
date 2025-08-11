using Microsoft.AspNetCore.Authorization;

namespace statejitsss.Authentication.JWT
{
    public static class AuthorizationService
    {
        public static void AddAuthorizationPolicies(this IServiceCollection services)
        {
            // Register custom authorization handler
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();

            // Add authorization policies
            services.AddAuthorization(options =>
            {
                #region policy
                options.AddPolicy("all-permission", policy =>
                    policy.Requirements.Add(new PermissionRequirement("all-permission")));

                options.AddPolicy("approver", policy =>
                    policy.RequireRole("approver"));

                options.AddPolicy("operator", policy =>
                    policy.RequireRole("operator"));

                options.AddPolicy("can-view", policy =>
                {
                    policy.RequireRole("approver", "operator");
                    policy.Requirements.Add(new PermissionRequirement("can-view"));
                });

                // Do Not Allow Permission
                options.AddPolicy("DoNotAllow", policy => policy.RequireAssertion(_ => false));
                #endregion
            });
        }
    }
}
