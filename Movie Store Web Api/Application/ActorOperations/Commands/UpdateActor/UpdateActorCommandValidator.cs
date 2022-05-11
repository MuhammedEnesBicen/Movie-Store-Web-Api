using FluentValidation;

namespace Movie_Store_Web_Api.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
            RuleFor(command => command.Model.FirstName.Length).GreaterThan(3);
            RuleFor(command => command.Model.LastName.Length).GreaterThan(3);
        }
    }
}
