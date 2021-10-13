using Master.Core.Logging;
using Master.Microservices.Catalog.DataAccess.Models;
using Master.Microservices.Catalog.DataAccess.Services;
using Master.Microservices.Catalog.ViewModels;
using Master.Microservices.Common.Bases.Cqrs;
using MediatR;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.Handlers.Commands
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
            private readonly ICatalogService _catalogService;
            public AddCategoryCommandHandler(ILog<AddCategoryCommandHandler> log, ICatalogService catalogService) : base(log)
            {
                _catalogService = catalogService;
            }
            public override async Task<Response> ProcessAsync(Command request)
            {
                var cat = new ProductCategory { Name = request.ProductCategoryVm.Name, Description = request.ProductCategoryVm.Description };
                var response = await _catalogService.AddCategoryAsync(cat);
                var catVm = new ProductCategoryViewModel { Id = response.Id, Name = response.Name, Description = response.Description };
                return new Response { productCategoryVm = catVm };
            }
        }
    }
}
