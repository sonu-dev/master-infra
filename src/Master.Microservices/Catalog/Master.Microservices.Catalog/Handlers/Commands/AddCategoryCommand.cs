using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Orders.ViewModels;
using Master.Microservices.Common.Bases.Cqrs;
using MediatR;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Handlers.Commands
{
    public static class AddCategoryCommand
    {
        // Command
        public class Command : IRequest<Response>
        {
            public Command(ProductCategoryViewModel productCategoryVm)
            {
                ProductCategoryVm = productCategoryVm;
            }
            public ProductCategoryViewModel ProductCategoryVm { get; private set; }
        }

        // Response
        public class Response
        {
            public ProductCategoryViewModel productCategoryVm { get; set; }
        }

        // Handler
        public class AddCategoryCommandHandler : RequestHandlerBase<AddCategoryCommandHandler, Command, Response>
        {
            private readonly IProductService _productService;
            public AddCategoryCommandHandler(ILog<AddCategoryCommandHandler> log, IProductService productService) : base(log)
            {
                _productService = productService;
            }
            public override async Task<Response> ProcessAsync(Command request)
            {
                var cat = new ProductCategory { Name = request.ProductCategoryVm.Name, Description = request.ProductCategoryVm.Description };
                var response = await _productService.AddCategoryAsync(cat);
                var catVm = new ProductCategoryViewModel { Id = response.Id, Name = response.Name, Description = response.Description };
                return new Response { productCategoryVm = catVm };
            }
        }
    }
}
