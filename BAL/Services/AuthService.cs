using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using statejitsss.BAL.Interfaces;
using statejitsss.Models;
using System.Security.Claims;
using System.Text.Json;

namespace statejitsss.BAL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private UserModel _user = new UserModel();

        public AuthService(IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;

            if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                var claims = httpContextAccessor.HttpContext.User.Claims;

                _user.UserId = long.TryParse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out long userId) ? userId : 0;
                _user.UserName = claims.FirstOrDefault(c => c.Type == "name")?.Value ??
                claims.FirstOrDefault(c => c.Type == "username")?.Value ??
                claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                _user.Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                _user.Level = claims.FirstOrDefault(c => c.Type == "level")?.Value;
                _user.Scope = claims.FirstOrDefault(c => c.Type == "scope")?.Value;
                _user.UserEmail = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                _user.RoleId = long.TryParse(claims.FirstOrDefault(c => c.Type == "roleId")?.Value, out long roleId) ? roleId : null;
                _user.LevelId = long.TryParse(claims.FirstOrDefault(c => c.Type == "levelId")?.Value, out long levelId) ? levelId : null;
                _user.ScopeId = long.TryParse(claims.FirstOrDefault(c => c.Type == "scopeId")?.Value, out long scopeId) ? scopeId : null;
                _user.CreatedBy = long.TryParse(claims.FirstOrDefault(c => c.Type == "created_by")?.Value, out long createdBy) ? createdBy : null;
                _user.Designation = claims.FirstOrDefault(c => c.Type == "designation")?.Value;
                _user.TokenType = claims.FirstOrDefault(c => c.Type == "typ")?.Value;

                var permissionsClaims = claims
                    .Where(c => c.Type == "permissions")
                    .SelectMany(c =>
                        JsonSerializer.Deserialize<List<string>>(c.Value) ?? new List<string>()
                    )
                    .ToList();

                if (permissionsClaims.Any())
                {
                    _user.Permissions = permissionsClaims;
                }

            }

        }

        public UserModel User
        {
            get
            {
                return _user;
            }
        }
    }
}
