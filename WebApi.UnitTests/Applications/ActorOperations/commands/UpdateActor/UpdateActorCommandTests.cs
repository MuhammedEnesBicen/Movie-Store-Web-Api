using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.UpdateActor;
using Movie_Store_Web_Api.DBOperations;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.commands.UpdateActor
{
    public class UpdateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void UpdateActorCommand_ShouldReturnError_WhenActorDoesntExist()
        {
            UpdateActorCommand command = new UpdateActorCommand(_context, _mapper);
            command.ActorId = 23;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Actor with this id doesnt exist");
        }
    }
}
