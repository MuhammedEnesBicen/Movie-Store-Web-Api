using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Movie_Store_Web_Api.Application.OrderOperations.Queries;
using Movie_Store_Web_Api.Application.OrderOperations.Commands.CreateOrder;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace Movie_Store_Web_Api.Controllers
{
    [Authorize]
    [Route("[controller]s")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMapper mapper, MovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrdersQuery query = new GetOrdersQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
            command.Model = model;
            CreateOrderModelValidator validator = new CreateOrderModelValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
            
        }
    }
}
