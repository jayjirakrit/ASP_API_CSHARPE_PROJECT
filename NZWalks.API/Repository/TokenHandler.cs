using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Models.DTO;
using NZWalks.API.Models.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repository
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<string> CreateTokenAsync(User userRequest)
        {
            // Create Claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, userRequest.Name));
            claims.Add(new Claim(ClaimTypes.Email, userRequest.Email));

            // Loop into roles of users
            userRequest.User_Role.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.RoleName));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims, "ApplicationCookies"),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            Console.WriteLine(new ClaimsIdentity(claims, "ApplicationCookies").IsAuthenticated);
            return Task.FromResult(jwtToken);
        }
    }
}
