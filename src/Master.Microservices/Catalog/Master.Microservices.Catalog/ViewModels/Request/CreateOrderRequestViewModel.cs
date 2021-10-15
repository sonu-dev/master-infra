using Master.Microservices.Common.Bases;
using System.Collections.Generic;

namespace Master.Microservices.Orders.ViewModels.Request
{
    public  class CreateOrderRequestViewModel : ApiRequestBase
    {
        public List<ProductViewModel> Products { get; set; }
        public string Description { get; set; }
    }
}
