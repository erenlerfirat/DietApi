using Core.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Entity.Dtos;
using System.Linq;
using Core.Abstract;

public class JwtHelper : IJwtHelper
{
    public string SecretKey = AppSettingsHelper.GetValue("Token", "");
    public UserDetailsDto UserDetailsDto { get; set; }
    public string CreateToken(UserTokenRequest request, int expirationMinutes = 10080)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.NameIdentifier, request.UserId.ToString()),
                new(ClaimTypes.Role, request.RoleType.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        //token = token.Split(" ")[1]; // Cut Bearer prefix
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SymmetricKeyHelper.GetSymmetricKey(),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        return tokenHandler.ValidateToken(token, validationParameters, out _);

    }
    public UserDetailsDto GetUserDetails(ClaimsPrincipal principal)
    {
        var id = Convert.ToInt32(principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
        var roleType = Convert.ToInt16(principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value);

        var result = new UserDetailsDto
        {
            UserId = id,
            Role = roleType,
        };
        UserDetailsDto = result;
        return result;
    }

}
public static class SymmetricKeyHelper
{
    public static SymmetricSecurityKey GetSymmetricKey()
    {
        var key = Encoding.ASCII.GetBytes(AppSettingsHelper.GetValue("Token", ""));
        return new SymmetricSecurityKey(key);
    }
}