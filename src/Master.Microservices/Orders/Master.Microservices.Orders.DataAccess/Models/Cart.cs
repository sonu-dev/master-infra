using Master.Microservices.Common.Bases;
using System;
using System.Collections.Generic;

namespace Master.Microservices.Catalog.DataAccess.Models
{
    public class Cart : EntityBase
    {       
        public int TotalAmount { get; set; }      
        public ICollection<CartItem> Items { get; set; }
    }
}
