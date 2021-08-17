using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Repository;
using Master.Microservices.Orders.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ApiControllerBase<ProductController>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductController(ILog<ProductController> log, IProductCategoryRepository productCategoryRepository) : base(log)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        public async Task<IList<ProductCategoryViewModel>> GetProductCategoriesAsync()
        {
           var productCategories = await _productCategoryRepository.GetAllAsync();
           return productCategories.Select(cat => new ProductCategoryViewModel() { Id = cat.Id, Name = cat.Name, Description = cat.Description }).ToList();
        }
    }
}
