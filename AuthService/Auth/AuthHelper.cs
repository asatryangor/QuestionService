using AuthService.Constants;
using AuthService.Data.Entities;
using AuthService.Utils.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Auth
{
    public class AuthHelper
    {
        public static string GenerateToken(User user, AuthSettings authSettings)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            
            if (user.Role.Name == RoleConfiguration.UserRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, RoleConfiguration.UserRole));
            }
            else if (user.Role.Name == RoleConfiguration.AdminRole)
            {
                claims.Add(new Claim(ClaimTypes.Role, RoleConfiguration.UserRole));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, RoleConfiguration.GuestRole));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(authSettings.SecretKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer: authSettings.Issuer,
                audience: authSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(authSettings.ExpiresInMins),
                signingCredentials: signingCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}