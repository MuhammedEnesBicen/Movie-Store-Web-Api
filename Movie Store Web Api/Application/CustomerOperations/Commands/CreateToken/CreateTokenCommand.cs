using AutoMapper;
using Microsoft.Extensions.Configuration;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.TokenOpeartions;
using Movie_Store_Web_Api.TokenOpeartions.Models;
using System;
using System.Linq;

namespace Movie_Store_Web_Api.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;


        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (customer is not null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.ExpirationDate.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("mail or password is wrong");
            }


        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
