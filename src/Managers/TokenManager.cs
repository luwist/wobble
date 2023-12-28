using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using wobble.src.Models;

namespace wobble.src.Managers
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _config;

        public TokenManager(IConfiguration config)
        {
            this._config = config;
        }

        public string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim("id", user.Id.ToString()),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("username", user.Username),
                new Claim("email", user.Email),
                new Claim("createdAt", user.CreatedAt.ToString())
            };
            
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config.GetSection("Jwt")["Key"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: this._config.GetSection("Jwt")["Issuer"],
                audience: this._config.GetSection("Jwt")["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);;
        }
    }
}