using System;

namespace Master.Microservices.Payments.DataAccess.Models
{
    public class OrderPayment
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

    public enum PaymentType
    {
        DebitCard,
        CreditCard,
        NetBanking,
        CashOnDelivery
    }

    public enum PaymentStatus
    {
       UnPaid,
       Success,
       Failiure
    }
}
