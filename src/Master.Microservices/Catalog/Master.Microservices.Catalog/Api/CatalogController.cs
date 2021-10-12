using Master.Core.Logging;
using Master.Microservices.Catalog.Handlers.Queries;
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
            var response = await _mediator.Send(new GetAllCategoriesQuery());
            return new GetProductCategoriesResponseViewModel
            { Categories = response.Categories?.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description }).ToList() };
        }
    }
}
