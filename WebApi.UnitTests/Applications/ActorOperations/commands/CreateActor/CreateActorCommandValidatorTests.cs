using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.CreateActor;
using System.Collections.Generic;
using System.Linq;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.commands.CreateActor
{
    public class CreateActorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void CreateActorCommand_ShouldReturnError_WhenInputsAreInvalid()
        {
            CreateActorCommand command = new CreateActorCommand(null, null);
            command.Model = new CreateActorModel() { FirstName = "z", LastName = "st", MovieIds = new List<int> { 12 } };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count().Should().BeGreaterThan(0);
        }
    }
}
