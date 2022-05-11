using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using System;
using System.Linq;
namespace Movie_Store_Web_Api.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public MovieStoreDbContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id ==CustomerId);
            if (customer is  null)
                throw new InvalidOperationException("there is no customer with this id");
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
