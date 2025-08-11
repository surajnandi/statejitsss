using System.Security.Claims;

namespace statejitsss.Authentication.JWT
{
    public class AuthClaimModel
    {
        public List<Claim> Claims { get; set; }
        public string RefreshedAccessToken { get; set; }
    }
}
