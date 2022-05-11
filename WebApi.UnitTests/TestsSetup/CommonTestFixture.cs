using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_Web_Api.Common;
using Movie_Store_Web_Api.DBOperations;


namespace WebApi.UnitTests.TestsSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDB").Options;
            Context = new MovieStoreDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddGenres();
            Context.AddActors();
            Context.SaveChanges();//Movies need actor entities because of that savechanges method called in here

            Context.AddDirectors();
            Context.AddMovies();
            Context.AddOrders();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
