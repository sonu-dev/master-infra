using Master.Microservices.Common.Bases;
using System;
using System.Collections.Generic;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class Cart : EntityBase
    {       
        public int TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}
