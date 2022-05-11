using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Store_Web_Api.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre { Name = "Science Fiction" },
                    new Genre { Name = "Romance" }
                    );

                context.Actors.AddRange(
                    new Actor { FirstName = "David", LastName = "somebody", Movies = new List<Movie> { } },
                    new Actor { FirstName = "Puddy", LastName = "somebody", Movies = new List<Movie> {  } }
                    );

                context.Directors.AddRange(
                    new Director { FirstName = "David", LastName = "SomeBody", DirectedMovies = new List<Movie> { } },
                    new Director { FirstName = "Ashly", LastName = "SomeBody", DirectedMovies = new List<Movie> {  } }
                    );

                context.Customers.AddRange(
                    new Customer { FirstName = "Test", LastName = "User" }
                    );

                context.Movies.AddRange(
                    new Movie { Name = "Dune", MovieYear = DateTime.Parse("12/12/2021"), Price = 9.99, DirectorId = 1, GenreId = 1, Actors = new List<Actor> { } },
                    new Movie { Name = "Lord Of The Rings", MovieYear = DateTime.Parse("12/12/2011"), Price = 9.99, DirectorId = 1, GenreId = 1, Actors = new List<Actor> {  } }
                        );

                context.SaveChanges();

            }

        }
    }
}
