using Master.Core.Logging;
using Master.Microservices.Catalog.Handlers.Commands;
using Master.Microservices.Catalog.Handlers.Queries;
using Master.Microservices.Catalog.ViewModels;
using Master.Microservices.Catalog.ViewModels.Response;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Catalog.Api
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ApiControllerBase<CatalogController>
    {
        public CatalogController(ILog<CatalogController> log, IMediatorPublisher publisher) : base(log, publisher)
        {
            
        }

        [HttpGet]
        public async Task<GetProductCategoriesResponseViewModel> GetProductCategoriesAsync()
        {
            var response = await Mediator.PublishAsync(new GetAllCategoriesQuery.Query());
            return new GetProductCategoriesResponseViewModel
            { Categories = response.Categories?.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description }).ToList() };
        }

        [HttpPost]
        public async Task<ProductCategoryViewModel> AddCategoryAsync(ProductCategoryViewModel productCategoryVm)
        {
            var response = await Mediator.PublishAsync(new AddCategoryCommand.Command(productCategoryVm));
            return response.productCategoryVm;
        }
    }
}
