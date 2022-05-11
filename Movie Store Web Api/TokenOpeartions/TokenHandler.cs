using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Movie_Store_Web_Api.Entities;
using Movie_Store_Web_Api.TokenOpeartions.Models;

namespace Movie_Store_Web_Api.TokenOpeartions
{
    public class TokenHandler
    {
        public IConfiguration Configuration;
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(Customer customer)
        {
            Token  tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            tokenModel.ExpirationDate = DateTime.Now.AddMinutes(15);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience : Configuration["Token:Audience"],
                expires : tokenModel.ExpirationDate,
                notBefore : DateTime.Now,
                signingCredentials : credentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //token is creating
            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
