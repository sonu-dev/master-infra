namespace Master.Microservices.Catalog.Host
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
