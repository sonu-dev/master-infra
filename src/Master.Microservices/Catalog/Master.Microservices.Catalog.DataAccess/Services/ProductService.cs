using Master.Core.Logging;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using Master.Microservices.Common.Bases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.DataAccess.Repository
{
    public class ProductService : ServiceBase<ProductService, OrderDataContext>, IProductService
    {
       
        public ProductService(ILog<ProductService> log, OrderDataContext dataContext) 
            : base(log, dataContext)
        {
        }

        #region IProductService Members
        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {
            return await DataContext.Set<ProductCategory>().ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryByIdAsync(int categoryId)
        {
            return await DataContext.Set<ProductCategory>().FindAsync(categoryId);
        }

        public async Task<ProductCategory> AddCategoryAsync(ProductCategory productCategory)
        {
            var cat = await GetCategoryByIdAsync(productCategory.Id);
            if(cat == null)
            {
               await DataContext.ProductCategories.AddAsync(productCategory);
               await DataContext.SaveChangesAsync();
            }
            return productCategory;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await DataContext.Products.AddAsync(product);
            await DataContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await DataContext.Products.Include(p => p.Category).ToListAsync();
            return products;
        }      

        #endregion
    }
}
