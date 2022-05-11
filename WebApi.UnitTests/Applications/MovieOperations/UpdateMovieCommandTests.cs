using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.UpdateMovie;
using Movie_Store_Web_Api.DBOperations;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.MovieOperations
{
    public class UpdateMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void UpdateMovieCommand_ShouldThrowErrors_WhenMovieDoesNotExist()
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.MovieId = -12;

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("movie with this id doesnt exist");
        }
    }
}
