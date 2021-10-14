using Master.Core.Logging;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.ViewModels;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Handlers.Commands
{
    public static class CreateProductCommand
    {
        // Command
        public class Command : IRequest<Response>
        {
            public Command(ProductViewModel productVm)
            {
                ProductVm = productVm;
            }
            public ProductViewModel ProductVm { get; private set; }
        }

        // Response
        public class Response
        {
            public bool Success { get; set; }
        }

        // Handler
        public class AddProductCommandHandler : RequestHandlerBase<AddProductCommandHandler, Command, Response>
        {
            private readonly IProductService _productService;
            public AddProductCommandHandler(ILog<AddProductCommandHandler> log, IProductService productService) : base(log)
            {
                _productService = productService;
            }
            public override async Task<Response> ProcessAsync(Command request)
            {
                if (request.ProductVm == null)
                {
                    throw new ArgumentNullException(nameof(request.ProductVm));
                }

                var product = new Product
                {
                    Name = request.ProductVm.Name,
                    Description = request.ProductVm.Description,
                    Price = request.ProductVm.Price,
                    CategoryId = request.ProductVm.CategoryId,
                    IsEnabled = request.ProductVm.IsEnabled,
                    IsAvailable = request.ProductVm.IsAvailable
                };
                var response = await _productService.AddProductAsync(product);
                return new Response { Success = true };
            }
        }
    }
}
