using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Movie_Store_Web_Api.Application.CustomerOperations.Commands.CreateCustomer;
using Movie_Store_Web_Api.Application.CustomerOperations.Commands.CreateToken;
using Movie_Store_Web_Api.Application.CustomerOperations.Commands.DeleteCustomer;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.TokenOpeartions.Models;

namespace Movie_Store_Web_Api.Controllers
{


    [Route("[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CustomerController(MovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel model)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = model;
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }



        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = login;
            var token = command.Handle();

            return Ok(token);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context, _mapper);
            command.CustomerId=id;
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
