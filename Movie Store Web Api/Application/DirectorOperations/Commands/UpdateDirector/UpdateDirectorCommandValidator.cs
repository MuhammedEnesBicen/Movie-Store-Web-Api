using FluentValidation;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {

            public UpdateDirectorCommandValidator()
            {
                RuleFor(command => command.DirectorId).GreaterThan(0);
                RuleFor(command => command.Model.FirstName.Length).GreaterThan(3);
                RuleFor(command => command.Model.LastName.Length).GreaterThan(3);
            }
        
    }
}
