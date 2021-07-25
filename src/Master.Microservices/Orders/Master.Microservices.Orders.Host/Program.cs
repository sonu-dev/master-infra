using Master.Microservices.Orders.Host;

namespace Master.Microservices.Order.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new OrdersServiceHost();
            host.Run(args);
        }            
    }
}
