using Microsoft.EntityFrameworkCore;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class OrdersDataContext : DbContext
    {
        public OrdersDataContext(DbContextOptions<OrdersDataContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
