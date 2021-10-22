using Master.Microservices.Orders.DataAccess.Models;
using MediatR;

namespace Master.Microservices.Orders.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<bool>
    {
        public CreateProductCommand(Product product)
        {
            Product = product;
        }
        public Product Product { get; private set; }
    }
}
