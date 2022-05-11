using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Linq;
namespace Movie_Store_Web_Api.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {


        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderModel Model;

        public CreateOrderCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(o => o.MovieId==Model.MovieId && o.CustomerId==Model.CustomerId);
            if (order is not null)
                throw new InvalidOperationException("Order already exist");
            Order newOrder = _mapper.Map<Order>(Model);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }
    }

    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
