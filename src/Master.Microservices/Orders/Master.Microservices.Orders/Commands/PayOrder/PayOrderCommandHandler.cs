using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Commands.PayOrder
{
    public class PayOrderCommandHandler : IRequestHandler<PayOrderCommand, bool>
    {
        public async Task<bool> Handle(PayOrderCommand request, CancellationToken cancellationToken)
        {
            // To Call Payment Microservice...

            return await Task.FromResult(true);
        }
    }
}
