using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Order { CustomerId=1,MovieId=1,OrderDate=DateTime.Parse("11/2/2017"),Price=13},
                new Order { CustomerId = 2, MovieId = 2, OrderDate = DateTime.Parse("11/2/2018"), Price = 13 },
                new Order { CustomerId = 1, MovieId = 3, OrderDate = DateTime.Parse("11/2/2019"), Price = 13 });
        }

    }
}
