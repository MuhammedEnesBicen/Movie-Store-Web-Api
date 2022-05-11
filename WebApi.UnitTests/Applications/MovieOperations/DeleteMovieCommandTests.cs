using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.DeleteMovie;
using Movie_Store_Web_Api.DBOperations;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.MovieOperations
{
    public class DeleteMovieCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteMovieCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void DeleteMovieCommand_ShouldReturnError_WhenActorDoesntExist()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context, _mapper);
            command.MovieId = 12;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("there is no movie with this id");

        }
    }
}
