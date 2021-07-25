using System;

namespace Master.Microservices.Orders.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public DateTime CreationTime { get; set; }
        public int CreatedBy { get; set; }
    }
}
