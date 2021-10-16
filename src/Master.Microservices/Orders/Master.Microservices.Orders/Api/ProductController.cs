﻿using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.Handlers.Product;
using Master.Microservices.Orders.ViewModels;
using Master.Microservices.Orders.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            var cats = await Mediator.PublishAsync(new GetProductCategories());
            return new GetProductCategoriesResponseViewModel
            { Categories = cats.Select(c => new ProductCategoryViewModel { Id = c.Id, Name = c.Name, Description = c.Description }).ToList() };
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<bool> CreateCategoryAsync(ProductCategoryViewModel productCategoryVm)
        {
            var cat = new ProductCategory
            {
                Name = productCategoryVm.Name,
                Description = productCategoryVm.Description,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            var result = await Mediator.PublishAsync(new CreateProductCategory(cat));
            return result;
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<bool> CreateProductAsync(ProductViewModel productVm)
        {
            var product = new Product
            {
                Name = productVm.Name,
                Description = productVm.Description,
                Price = productVm.Price,
                CategoryId = productVm.CategoryId,
                IsEnabled = productVm.IsEnabled,
                IsAvailable = productVm.IsAvailable,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            var result = await Mediator.PublishAsync(new CreateProduct(product));
            return result;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<GetProductsResponseViewModel> GetProductsAsync(List<int> productIds)
        {
            var products = await Mediator.PublishAsync(new GetProducts(productIds));
            return new GetProductsResponseViewModel
            {
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    IsAvailable = p.IsAvailable,
                    IsEnabled = p.IsEnabled,                    
                    Category = new ProductCategoryViewModel
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description
                    }
                }).ToList()
            };
        }
    }
}