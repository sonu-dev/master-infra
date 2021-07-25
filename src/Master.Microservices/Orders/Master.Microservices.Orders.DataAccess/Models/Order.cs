using System;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatedBy { get; set; }
    }

    public enum OrderStatus
    {
        UnPaid,
        Paid
    }
}
