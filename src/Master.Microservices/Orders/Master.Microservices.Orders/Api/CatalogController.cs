using Master.Core.Logging;
using Master.Microservices.Catalog.Handlers.QueryHandlers;
using Master.Microservices.Catalog.ViewModels;
using Master.Microservices.Catalog.ViewModels.Response;
using Master.Microservices.Common.Bases;
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
        private readonly IMediator _mediator;
        public CatalogController(ILog<CatalogController> log, IMediator mediator) : base(log)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetProductCategoriesResponseViewModel> GetProductCategoriesAsync()
        {
            var productCategories = await _mediator.Send(new GetProductCategoriesQuery());
            return new GetProductCategoriesResponseViewModel
            { Categories = productCategories.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description }).ToList() };
        }
    }
}
