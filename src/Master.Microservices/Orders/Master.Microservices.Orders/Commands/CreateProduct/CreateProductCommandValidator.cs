using FluentValidation;

namespace Master.Microservices.Orders.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Product.Name)
              .NotEmpty().WithMessage("{Name} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(c => c.Product.Description)
             .NotEmpty().WithMessage("{Description} is required.")
             .NotNull()
             .MaximumLength(100).WithMessage("{Description} must not exceed 100 characters.");

            RuleFor(c => c.Product.Price)
               .NotEmpty().WithMessage("{Price} is required.")
               .GreaterThan(0).WithMessage("{Price} should be greater than zero.");
        }
    }
}
