using FluentValidation;

namespace Master.Microservices.Orders.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(c => c.ProductCategory.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull();

            RuleFor(c => c.ProductCategory.Description)
               .NotEmpty().WithMessage("{Description} is required.")
               .NotNull();
        }
    }
}
