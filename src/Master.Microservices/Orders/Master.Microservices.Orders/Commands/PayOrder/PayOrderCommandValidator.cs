using FluentValidation;

namespace Master.Microservices.Orders.Commands.PayOrder
{
    public class PayOrderCommandValidator : AbstractValidator<PayOrderCommand>
    {
        public PayOrderCommandValidator()
        {
            RuleFor(c => c.OrderIds)
               .NotEmpty().WithMessage("{OrderDescription} is required.");
        }
    }
}
