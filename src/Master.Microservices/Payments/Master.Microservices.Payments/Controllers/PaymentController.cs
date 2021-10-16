using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Bases.Cqrs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ApiControllerBase<PaymentController>
    {
        public PaymentController(ILog<PaymentController> log, IMediatorPublisher mediator) : base(log, mediator)
        {

        }

        [HttpGet]
        public async Task<string> TestAsync()
        {
            return await Task.FromResult($"Server called at {DateTime.Now}");
        }
    }
}
