using MediatR;
using System.Collections.Generic;

namespace Master.Microservices.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand: IRequest<bool>
    {       
            public CreateOrderCommand(List<int> productIds, string orderDescription)
            {
                ProductIds = productIds;
                OrderDescription = orderDescription;
            }

            public List<int> ProductIds { get; private set; }
            public string OrderDescription { get; private set; }
        
    }
}
