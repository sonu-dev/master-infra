using Master.Core.Logging;
using Master.Microservices.Common.Bases.Cqrs;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Handlers.Commands
{
    public static class CreateOrderCommand
    {
        // Command
        public class Command: IRequest<Response>
        {
            public Command(List<Product> products, string orderDescriptoin)
            {
                Products = products;
                OrderDescriptoin = orderDescriptoin;
            }
            public List<Product> Products { get; private set; }
            public string OrderDescriptoin { get; private set; }
        }

        // Response
        public class Response
        {
            public bool Success { get; set; }
        }

        public class AddOrderCommandHandler : RequestHandlerBase<AddOrderCommandHandler, Command, Response>
        {
            private readonly IOrderService _orderService;
            public AddOrderCommandHandler(ILog<AddOrderCommandHandler> log, IOrderService orderService) : base(log)
            {
                _orderService = orderService;
            }
            public override async Task<Response> ProcessAsync(Command request)
            {
                if (request.Products == null || request.Products.Count == 0)
                {
                    throw new ArgumentNullException(nameof(request.Products));
                }

                var result = await _orderService.CreateOrderAsync(request.Products, request.OrderDescriptoin);
                return new Response { Success = true };
            }
        }
    }
}
