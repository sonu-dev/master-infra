using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.Commands.CreateOrder;
using Master.Microservices.Orders.Commands.PayOrder;
using Master.Microservices.Orders.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ApiControllerBase<OrderController>
    {
        protected readonly IMediatorPublisher _mediator;
        public OrderController(ILog<OrderController> log, IMediatorPublisher mediator) : base(log)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Ping")]
        public async Task<string> PingAsync()
        {
            return await Task.FromResult($"Server called at {DateTime.Now}");
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<bool> CreateOrderAsync([FromBody] CreateOrderRequestViewModel request)
        {
            var command = new CreateOrderCommand(request.ProductIds, request.Description);
            var result = await _mediator.PublishAsync(command);
            return result;
        }

        [HttpPost]
        [Route("PayOrder")]
        public async Task<bool> PayOrderAsync([FromBody] List<int> orderIds)
        {
            var command = new PayOrderCommand(orderIds);
            var result = await _mediator.PublishAsync(command);
            return result;
        }
    }
}
