using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;


namespace WebApi.UnitTests.TestsSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Actor
                {
                    FirstName = "actor a",
                    LastName = "a last",
                    
                },
                new Actor
                {
                    FirstName = "actor b",
                    LastName = "last b",

                },
                new Actor
                {
                    FirstName = "actor c",
                    LastName = "last c",

                }
                );
            
        }
    }
}
