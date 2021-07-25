using System.Collections.Generic;

namespace Master.Microservices.Orders.ViewModels.Response
{
    public class GetOrdersResponseViewModel
    {
       public List<OrderViewModel> Orders { get; set; }
    }
}
