using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Orders.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet]
        public async Task<string> Get()
        {
            return await Task.FromResult<string>("Hello World!");
        }
    }
}
