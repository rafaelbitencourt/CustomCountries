using CustomCountries.API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CustomCountries.API.Repository
{
    public interface IAuthService
    {
        string Authenticate(string name, string password);
    }

    public class AuthService : IAuthService
    {
        private List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                Name = "rafael",
                Password = "1234"
            },
            new User
            {
                Id = 2,
                Name = "joao",
                Password = "abcd"
            }
        };

        public string Authenticate(string name, string password)
        {
            var user = users.Where(x => x.Name == name && x.Password == password).FirstOrDefault();
            
            if (user != null)
            {
                var roles = new List<string> { "default" };
                return "Bearer " + GenerateAccessToken(name, Guid.NewGuid().ToString(), roles.ToArray());
            }

            throw new AuthenticationException("Usuário ou senha inválidos.");
        }

        private string GenerateAccessToken(string name, string userId, string[] roles)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("customcountriescustomcountries"));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, name)
            };

            claims = claims.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role))).ToList();

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                "issuer",
                "audience",
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
