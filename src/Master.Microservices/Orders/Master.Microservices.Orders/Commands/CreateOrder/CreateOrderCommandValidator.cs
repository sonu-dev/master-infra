using FluentValidation;

namespace Master.Microservices.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.OrderDescription)
                .NotEmpty().WithMessage("{OrderDescription} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Description} must not exceed 200 characters.");

            RuleFor(c => c.ProductIds)
               .NotEmpty().WithMessage("{ProductIds} is required.");
        }
    }
}
