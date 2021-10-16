using Master.Microservices.Common.Bases;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Microservices.Payments.DataAccess.Models
{
    [Table("PaymentOrder", Schema = "Payments")]
    public class PaymentOrder : EntityBase
    {
        public int OrderId { get; set; }
        public Guid? TransactionId { get; set; }
        public decimal OrderAmount { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }       
    }
}
