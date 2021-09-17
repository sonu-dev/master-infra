using Master.Microservices.Catalog.DataAccess.TestData;
using Master.Microservices.Common.Bases;
using Microsoft.EntityFrameworkCore;

namespace Master.Microservices.Catalog.DataAccess.Models
{
    public class CatalogDataContext : MasterDbContextBase
    {
        public CatalogDataContext() { }
        public CatalogDataContext(DbContextOptions<CatalogDataContext> options)
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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
