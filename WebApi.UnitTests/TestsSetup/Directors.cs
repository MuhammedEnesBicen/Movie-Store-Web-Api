using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Director { FirstName = "1. director", LastName = "last 1" },
                new Director { FirstName = "2. director", LastName = "last 2" },
                new Director { FirstName = "3. director", LastName = "last 3" })
            ;
        }
    }
}
