using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Genre {Name="Science Fiction" },
                new Genre { Name="Drama"},
                new Genre { Name= "Romance"}

                );

        }
    }
}
