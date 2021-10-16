using Master.Microservices.Common.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Microservices.Payments.DataAccess.Models
{
   public class PaymentDataContext: MasterDbContextBase
    {
        public PaymentDataContext() { }
        public PaymentDataContext(DbContextOptions<PaymentDataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        public DbSet<PaymentOrder> PaymentOrders { get; set; }       
    }
}
