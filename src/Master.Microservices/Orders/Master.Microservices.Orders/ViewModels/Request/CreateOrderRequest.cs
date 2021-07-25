namespace Master.Microservices.Orders.ViewModels.Request
{
    public class CreateOrderRequest : RequestBase
    {
        public OrderViewModel Order { get; set; }
    }
}
