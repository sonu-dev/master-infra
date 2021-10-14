using System;
using System.Collections.Generic;

namespace Master.Microservices.Orders.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public List<OrderItemViewModel> Items { get; set; }
    }
}
