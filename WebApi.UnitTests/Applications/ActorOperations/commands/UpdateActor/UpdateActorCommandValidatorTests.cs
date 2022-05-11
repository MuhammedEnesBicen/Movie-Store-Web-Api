using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.UpdateActor;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.commands.UpdateActor
{
    public class UpdateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Fact]
        public void UpdateActorCommand_ShouldReturnError_WhenActorIdIsInvalid()
        {
            UpdateActorCommand command = new UpdateActorCommand(null, null);
            command.ActorId = -1;
            command.Model = new UpdateActorModel { FirstName = "", LastName = "" };

            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count().Should().BeGreaterThan(0);
        }
    }
}
