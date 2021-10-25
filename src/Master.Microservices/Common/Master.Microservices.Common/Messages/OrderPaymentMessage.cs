namespace Master.Microservices.Common.Messages
{
    public class OrderPaymentMessage
    {
        public int OrderId { get; set; }
        public decimal OrderAmount { get; set; }
    }
}
