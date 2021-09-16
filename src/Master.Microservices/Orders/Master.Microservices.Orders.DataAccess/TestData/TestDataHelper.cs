using Master.Microservices.Catalog.DataAccess.Models;

namespace Master.Microservices.Catalog.DataAccess.TestData
{
    public class TestDataHelper
    {
      public static ProductCategory[] GetProductCategories() => new ProductCategory[3]
      {
             new ProductCategory() { Id = 1, Name = "Electronics", Description = "Electronics",IsEnabled = true },
             new ProductCategory() { Id = 2, Name = "Books", Description = "Books",IsEnabled = true },
             new ProductCategory() { Id = 3, Name = "Fashion", Description = "Fashion",IsEnabled = true }
      };

        public static Product[] GetProducts() => new Product[4]
        {
             new Product() { Id = 1, CategoryId=1, Name = "Laptop", Description = "Laptop", Price = 50000, IsAvailable = true, IsEnabled = true },
             new Product() { Id = 2, CategoryId=1, Name = "Printer", Description = "Printer", Price = 30000, IsAvailable = true, IsEnabled = true },
             new Product() { Id = 3, CategoryId=1, Name = "Scanner", Description = "Laptop", Price = 70000, IsAvailable = true, IsEnabled = true },
             new Product() { Id = 4, CategoryId=2, Name = "Karma", Description = "Written By Sadguru", Price = 400, IsAvailable = true, IsEnabled = true }
        };
    }
}
