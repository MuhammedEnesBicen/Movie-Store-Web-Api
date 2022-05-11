using FluentValidation;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.Model.FirstName.Length).GreaterThan(3);
            RuleFor(command => command.Model.LastName.Length).GreaterThan(3);

        }
    }
}
