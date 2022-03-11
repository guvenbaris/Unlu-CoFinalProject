using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Domain.Jwt;

namespace UnluCoProductCatalog.Application.Jwt
{
    public class TokenGenarator
    {
        private readonly IConfiguration _configuration;
        public TokenGenarator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(User user, IList<string> userRoles)
        {
            var exp = DateTime.Now.AddMinutes(15);

            var token = new Token{Expiration = exp};


            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Id),
            };

            foreach (var role in  userRoles)
                if (role is not null)
                    authClaims.Add(new Claim(ClaimTypes.Role, Convert.ToString(role)));


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: exp, notBefore: DateTime.Now,
                signingCredentials: credentials,
                claims: authClaims
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(securityToken);
            token.AccessToken = accessToken;
            token.RefreshToken = Guid.NewGuid().ToString();

            return token;
        }
    }
}
