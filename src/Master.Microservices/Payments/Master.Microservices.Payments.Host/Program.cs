namespace Master.Microservices.Payments.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new PaymentServiceHost();
            host.Run(args);
        }       
    }
}
