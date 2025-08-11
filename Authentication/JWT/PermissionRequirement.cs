using Microsoft.AspNetCore.Authorization;

namespace statejitsss.Authentication.JWT
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string[] Permissions { get; }
        public PermissionRequirement(params string[] permissions)
        {
            Permissions = permissions;
        }
    }
}
