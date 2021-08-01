using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public ICollection<CartItem> Items { get; set; }
    }
}
