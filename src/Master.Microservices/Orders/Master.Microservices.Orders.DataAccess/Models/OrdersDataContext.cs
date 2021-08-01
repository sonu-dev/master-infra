using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.TestData;
using Microsoft.EntityFrameworkCore;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class OrdersDataContext : MasterDbContextBase
    {
        public OrdersDataContext() { }
        public OrdersDataContext(DbContextOptions<OrdersDataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
