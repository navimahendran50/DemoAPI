using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DemoAPI.Common;
using DemoAPI.Interfaces;
using DemoAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DemoAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IOptions<JwtOptions> options;
        private readonly SymmetricSecurityKey key;

        public TokenService(UserManager<AppUser> userManager, IOptions<JwtOptions> options)
        {
            this.userManager = userManager;
            this.options = options;
            this.key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(options.Value.Key));
        }
        public async Task<string> CreateTokenAsync(AppUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var userClaims = await userManager.GetClaimsAsync(user);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!)
            };
            claims.AddRange(userClaims);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = signingCredentials,
                Issuer = options.Value.Issuer,
                Audience = options.Value.Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return (string)tokenHandler.WriteToken(token);
        }
    }
}