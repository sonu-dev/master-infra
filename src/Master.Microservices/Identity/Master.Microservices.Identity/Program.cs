namespace Master.Microservices.Identity
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var host = new IdentityServiceHost();
            host.Run(args);
        }       
    }
}
