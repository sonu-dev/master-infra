namespace Master.Microservices.Payments.DataAccess
{
    public class Constants
    {
        public enum PaymentType
        {
            CardPayment,
            OnlineBanking,
            CashOnDelivery
        }

        public enum PaymentStatus
        {
            Success,
            Failure
        }
    }
}
