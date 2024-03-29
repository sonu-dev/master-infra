﻿using Master.Microservices.Orders.DataAccess.Models;
using System;

namespace Master.Microservices.Orders.DataAccess.TestData
{
    public class TestDataHelper
    {       
        public static ProductCategory[] GetProductCategories() => new ProductCategory[3]
        {
             new ProductCategory() { Id = 1, Name = "Electronics", Description = "Electronics",IsEnabled = true, CreatedBy=1, CreateTime= DateTime.Now, UpdateTime = DateTime.Now },
             new ProductCategory() { Id = 2, Name = "Books", Description = "Books",IsEnabled = true,CreatedBy=1, CreateTime= DateTime.Now, UpdateTime = DateTime.Now },
             new ProductCategory() { Id = 3, Name = "Fashion", Description = "Fashion",IsEnabled = true,CreatedBy=1, CreateTime= DateTime.Now, UpdateTime = DateTime.Now }
        };

        public static Product[] GetProducts() => new Product[4]
        {
             new Product() { Id = 1, CategoryId=1, Name = "Laptop", Description = "Laptop", Price = 50000, IsAvailable = true, IsEnabled = true,CreatedBy=1, CreateTime= DateTime.Now, UpdateTime = DateTime.Now },
             new Product() { Id = 2, CategoryId=1, Name = "Printer", Description = "Printer", Price = 30000, IsAvailable = true, IsEnabled = true,CreatedBy=1, CreateTime= DateTime.Now, UpdateTime = DateTime.Now },
             new Product() { Id = 3, CategoryId=1, Name = "Scanner", Description = "Laptop", Price = 70000, IsAvailable = true, IsEnabled = true,CreatedBy=1, CreateTime= DateTime.Now, UpdateTime = DateTime.Now },
             new Product() { Id = 4, CategoryId=2, Name = "Karma", Description = "Written By Sadguru", Price = 400, IsAvailable = true, IsEnabled = true,CreatedBy=1, CreateTime= DateTime.Now,UpdateTime = DateTime.Now }
        };
    }
}
