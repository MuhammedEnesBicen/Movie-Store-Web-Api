using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.CreateMovie;
using Movie_Store_Web_Api.DBOperations;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;


namespace WebApi.UnitTests.Applications.MovieOperations
{
    public class CreateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void CreateMovieCommand_ShouldReturnError_WhenMovieAlreadyExist()
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = new CreateMovieModel() { Name= "1. movie" };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("A movie with this name already exists");
        }
    }
}
