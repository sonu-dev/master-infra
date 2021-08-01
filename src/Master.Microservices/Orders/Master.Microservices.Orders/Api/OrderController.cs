using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Models;
using Master.Microservices.Orders.DataAccess.Repository;
using Master.Microservices.Orders.ViewModels;
using Master.Microservices.Orders.ViewModels.Request;
using Master.Microservices.Orders.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Api
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ApiControllerBase<OrderController>
    {
        private IOrderRepository _orderRepository;
        public OrderController(ILog<OrderController> log, IOrderRepository orderRepository) : base(log)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost(Name = "Create")]
        public async Task<bool> PostAsync([FromBody] CreateOrderRequest request)
        {
            var newOrder = new Order
            {               
                Description = request.Order.Description,
                Amount = request.Order.Amount,
                Status = (int)OrderStatus.UnPaid,
                CreatedTime = DateTime.Now,
                CreatedBy = request.UserId
            };
            return await _orderRepository.CreateOrdersAsync(new List<Order> { newOrder });
        }

        [HttpGet]
        public async Task<GetOrdersResponseViewModel> GetAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync(null);
            var ordersVm = orders.Select(o =>
                new OrderViewModel
                {
                    Description = o.Description,
                    Amount = o.Amount,
                    Status = o.Status,
                    CreationTime = o.CreatedTime,
                    CreatedBy = o.CreatedBy
                }
            ).ToList();
            return new GetOrdersResponseViewModel { Orders = ordersVm };
        }
    }
}
