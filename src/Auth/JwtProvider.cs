using Hermes.Identity.Dto;
using Hermes.Identity.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Identity.Auth
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings jwtSettings;
        public JwtProvider(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }
        public AuthDto Create(Guid userId, string role, string audience = null, IDictionary<string, IEnumerable<string>> claims = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "Hermes",
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthDto
            {
                AccessToken = tokenHandler.WriteToken(token),
                Role = role,
                Expires = token.ValidTo
            };
        }
    }
}
