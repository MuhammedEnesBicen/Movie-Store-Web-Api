using FluentValidation;

namespace Movie_Store_Web_Api.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.CustomerId).GreaterThan(0);
        }
    }
}
