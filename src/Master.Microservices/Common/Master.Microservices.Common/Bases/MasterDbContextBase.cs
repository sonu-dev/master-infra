using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
                    @"server=DESKTOP-TUCC31U\SQLEXPRESS;database=MasterDemo;user Id=masteradmin;password=Welcome1;");
            }
        }
    }
}
