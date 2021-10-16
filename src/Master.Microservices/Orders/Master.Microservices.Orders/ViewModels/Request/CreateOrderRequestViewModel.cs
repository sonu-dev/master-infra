using Master.Microservices.Common.Bases;
using System.Collections.Generic;

namespace Master.Microservices.Orders.ViewModels.Request
{
    public  class CreateOrderRequestViewModel : ApiRequestBase
    {
        public List<int> ProductIds { get; set; }
        public string Description { get; set; }
    }
}
