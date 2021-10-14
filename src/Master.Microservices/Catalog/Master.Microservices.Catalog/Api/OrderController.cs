using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ApiControllerBase<OrderController>
    {
        public OrderController(ILog<OrderController> log, IMediatorPublisher mediator) : base(log, mediator)
        {

        }

        [HttpPost]
        public async Task<bool> CreateOrderAsync(OrderViewModel orderViewModel)
        {

        }
    }
}
