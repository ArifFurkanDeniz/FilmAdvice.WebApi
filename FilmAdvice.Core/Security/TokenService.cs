using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using FilmAdvice.Core.Security.JwtSecurity;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;

namespace FilmAdvice.Core.Security
{
    public class TokenService : ITokenService
    {
        public TokenApiResponse GenerateToken(UserDto userDto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userDto.Email),
                new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
                
            };

            string accessToken = GenerateAccessToken(claims);
            string refreshToken = GenerateRefreshToken();

            var token = new TokenApiResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Expires = JwtTokenDefinitions.TokenExpirationTime.Ticks
            };

            return token;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var handler = new JwtSecurityTokenHandler();
    
            var securityTokenHanlder = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = JwtTokenDefinitions.Issuer,
                Audience = JwtTokenDefinitions.Audience,
                SigningCredentials = JwtTokenDefinitions.SigningCredentials,
                Subject = claimsIdentity,
                Expires = DateTime.Now.Add(JwtTokenDefinitions.TokenExpirationTime),
                NotBefore = DateTime.Now
            });
            string accessToken = handler.WriteToken(securityTokenHanlder);

            return accessToken;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
