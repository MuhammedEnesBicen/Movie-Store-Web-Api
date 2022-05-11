using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Store_Web_Api.Application.OrderOperations.Queries
{
    public class GetOrdersQuery
    {
        private readonly MovieStoreDbContext _context;

        public GetOrdersQuery(MovieStoreDbContext context)
        {
            _context = context;
        }

        public List<Order> Handle()
        {
            return _context.Orders.ToList();
        }
    }
}
