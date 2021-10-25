using System;

namespace Master.Microservices.Payments.ViewModels
{
    public class OrderPaymentViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal OrderAmount { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
