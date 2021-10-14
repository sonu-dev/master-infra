using Master.Core.Logging;
using Master.Microservices.Catalog.Handlers.Queries;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.Handlers.Commands;
using Master.Microservices.Orders.Handlers.Queries;
using Master.Microservices.Orders.ViewModels;
using Master.Microservices.Orders.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ApiControllerBase<ProductController>
    {
        public ProductController(ILog<ProductController> log, IMediatorPublisher mediator) : base(log, mediator)
        {

        }
       
        [HttpGet]
        [Route("GetProductCategories")]
        public async Task<GetProductCategoriesResponseViewModel> GetProductCategoriesAsync()
        {
            var response = await Mediator.PublishAsync(new GetProductCategories.Query());
            return new GetProductCategoriesResponseViewModel
            { Categories = response.Categories?.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description }).ToList() };
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<ProductCategoryViewModel> AddCategoryAsync(ProductCategoryViewModel productCategoryVm)
        {
            var response = await Mediator.PublishAsync(new AddCategoryCommand.Command(productCategoryVm));
            return response.productCategoryVm;
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<bool> AddProductAsync(ProductViewModel productVm)
        {
            var response = await Mediator.PublishAsync(new CreateProductCommand.Command(productVm));
            return response.Success;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<GetProductsResponseViewModel> GetProductsAsync()
        {
            var response = await Mediator.PublishAsync(new GetProductsQuery.Query());
            return new GetProductsResponseViewModel
            { Products = response.Products };
        }
    }
}
