using MediatR;
using System.Collections.Generic;

namespace Master.Microservices.Orders.Commands.PayOrder
{
    public class PayOrderCommand : IRequest<bool>
    {
        public PayOrderCommand(List<int> orderIds)
        {
            OrderIds = orderIds;
        }

        public List<int> OrderIds { get; private set; }
    }
}
