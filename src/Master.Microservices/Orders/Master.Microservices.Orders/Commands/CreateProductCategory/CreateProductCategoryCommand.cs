using Master.Microservices.Orders.DataAccess.Models;
using MediatR;

namespace Master.Microservices.Orders.Commands.CreateProductCategory
{
    public class CreateProductCategoryCommand : IRequest<bool>
    {
        public CreateProductCategoryCommand(ProductCategory productCategory)
        {
            ProductCategory = productCategory;
        }
        public ProductCategory ProductCategory { get; private set; }
    }
}
