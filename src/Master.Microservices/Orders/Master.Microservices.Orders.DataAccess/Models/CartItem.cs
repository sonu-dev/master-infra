using Master.Microservices.Common.Bases;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Catalog.DataAccess.Models
{
    public class CartItem : EntityBase
    {       
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }

        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
