using FluentValidation;
using System;

namespace Movie_Store_Web_Api.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderModelValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderModelValidator()
        {
            RuleFor(command => command.Model).NotNull();
            RuleFor(command => command.Model.OrderDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(command => command.Model.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.CustomerId).GreaterThan(0);
        }
    }
}
