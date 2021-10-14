namespace Master.Microservices.Orders.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new CatalogServiceHost();
            host.Run(args);
        }            
    }
}
