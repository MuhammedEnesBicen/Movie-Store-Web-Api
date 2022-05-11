using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.DeleteActor;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.commands.DeleteActor
{
    public class DeleteActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void DeleteActorCommand_ShouldReturnError_WhenActorIdIsInvalid()
        {
            DeleteActorCommand command = new DeleteActorCommand(null,null);
            command.ActorId = -1;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
    }
}
