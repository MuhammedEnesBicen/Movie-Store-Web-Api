﻿using Microsoft.EntityFrameworkCore;
using Movie_Store_Web_Api.Entities;

namespace Movie_Store_Web_Api.DBOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options){}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get ; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
