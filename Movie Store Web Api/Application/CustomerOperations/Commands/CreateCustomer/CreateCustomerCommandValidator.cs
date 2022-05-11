using FluentValidation;

namespace Movie_Store_Web_Api.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.Model.FirstName.Length).GreaterThan(3);
            RuleFor(command => command.Model.LastName.Length).GreaterThan(3);

        }
    }
}
