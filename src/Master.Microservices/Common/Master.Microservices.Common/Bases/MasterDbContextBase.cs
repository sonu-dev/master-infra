using Microsoft.EntityFrameworkCore;

namespace Master.Microservices.Common.Bases
{
    public class MasterDbContextBase : DbContext
    {
        public MasterDbContextBase() { }
        public MasterDbContextBase(DbContextOptions options) : base(options) 
        {           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // For Migration
            {
                optionsBuilder.UseSqlServer(
                    @"server=AARYA\SQLEXPRESS;database=MasterStore;user Id=sonu;password=welcome1;");
            }
        }
    }
}
