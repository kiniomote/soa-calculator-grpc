using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GrpcCalculateService.Models;
using Microsoft.IdentityModel.Tokens;

namespace GrpcCalculateService.Services
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Username = "user12345", Password = "12345" },
        };

        public string GenerateToken(string login, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == login && u.Password == password);

            if (user == null)
                return string.Empty;

            ClaimsIdentity claimsIdentity = ClaimsIndentityByUser(user);

            return EncodeJwt(claimsIdentity);
        }

        private ClaimsIdentity ClaimsIndentityByUser(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "default")
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        private string EncodeJwt(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
