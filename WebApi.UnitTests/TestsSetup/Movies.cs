using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            var actor = context.Actors.First();
            
            context.AddRange(
                new Movie
                {
                    Name = "1. movie",
                    Price = 12,
                    DirectorId = 1,
                    GenreId = 1,
                    IsActive = true,
                    MovieYear = DateTime.Parse("12/12/1987"),
                    Actors = new List<Actor> { actor}
                },
                 new Movie
                 {
                     Name = "2. movie",
                     Price = 20,
                     DirectorId = 1,
                     GenreId = 1,
                     IsActive = true,
                     MovieYear = DateTime.Parse("12/12/1977")
                     
                 },
                  new Movie
                  {
                      Name = "3. movie",
                      Price = 30,
                      DirectorId = 1,
                      GenreId = 1,
                      IsActive = true,
                      MovieYear = DateTime.Parse("12/12/1967")
                  }
                );
            ;
        }
    }
}
