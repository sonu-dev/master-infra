﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Orders.DataAccess.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }       

        [ForeignKey("Cart")]
        public int CartId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public DateTime CreatedTime { get; set; }
        public int CreatedBy { get; set; }       
        public Cart Cart { get; set; }
    }

    public enum OrderStatus
    {
        UnPaid,
        Paid       
    }
}
