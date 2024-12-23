using Entity.Dtos;
using System.Security.Claims;

namespace Core.Abstract
{
    public interface IJwtHelper
    {
        string CreateToken(UserTokenRequest request, int expirationMinutes = 10080);
        ClaimsPrincipal ValidateToken(string token);
        UserDetailsDto GetUserDetails(ClaimsPrincipal principal);
        public UserDetailsDto UserDetailsDto { get; set; }

    }
}
