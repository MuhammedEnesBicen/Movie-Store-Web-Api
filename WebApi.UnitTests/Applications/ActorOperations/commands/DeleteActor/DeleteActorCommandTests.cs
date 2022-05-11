using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.DeleteActor;
using Movie_Store_Web_Api.DBOperations;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.commands.DeleteActor
{
    public class DeleteActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void DeleteActorCommand_ShouldReturnError_WhenActorDoesntExist()
        {
            DeleteActorCommand command = new DeleteActorCommand(_context, _mapper);
            command.ActorId = 12;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("there is no actor with this id");

        }

        [Fact]
        public void DeleteActorCommand_ShouldReturnError_WhenActionEffectOtherDBtables()
        {

            DeleteActorCommand command = new DeleteActorCommand(_context, _mapper);
            command.ActorId = 1;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("You cannot delete this actor because there are movie entries which has this actor infos.");

        }
    }
}
