using Master.Microservices.Orders.DataAccess.TestData;
using Master.Microservices.Common.Bases;
using Microsoft.EntityFrameworkCore;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class OrderDataContext : MasterDbContextBase
    {
        public OrderDataContext() { }
        public OrderDataContext(DbContextOptions<OrderDataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Insert Initial data
            modelBuilder.Entity<ProductCategory>().HasData(TestDataHelper.GetProductCategories());
            modelBuilder.Entity<Product>().HasData(TestDataHelper.GetProducts());
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
