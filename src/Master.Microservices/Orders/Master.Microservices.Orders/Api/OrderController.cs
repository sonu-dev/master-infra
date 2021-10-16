using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.Handlers.Order;
using Master.Microservices.Orders.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<bool> CreateOrderAsync(CreateOrderRequestViewModel request)
        {
            var command = new CreateOrder(request.ProductIds, request.Description);
            var result = await Mediator.PublishAsync(command);
            return result;
        }

        [HttpPost]
        public async Task<bool> DoPaymentrAsync(List<int> orderIds)
        {
            var command = new DoPayment(orderIds);
            var result = await Mediator.PublishAsync(command);
            return result;
        }
    }
}
