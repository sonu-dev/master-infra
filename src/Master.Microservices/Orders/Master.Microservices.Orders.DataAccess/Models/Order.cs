﻿using Master.Microservices.Common.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Orders.DataAccess.Models
{
    [Table("Orders", Schema = "Orders")]
    public class Order : EntityBase 
    {            
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }

        public List<OrderItem> Items { get; set; }
    }

    public enum OrderStatus
    {
        Created,
        InitiatePayment,
        PaymentFailed,
        Completed
    }
}
