using FluentValidation;

namespace Movie_Store_Web_Api.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.Model.FirstName.Length).GreaterThan(3);
            RuleFor(command => command.Model.LastName.Length).GreaterThan(3);

        }
    }
}
