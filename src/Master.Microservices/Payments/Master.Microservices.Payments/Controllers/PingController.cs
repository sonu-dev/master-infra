using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController 
    {
        [HttpGet]
        public async Task<string> PingAsync()
        {
            return await Task.FromResult($"Ping PaymentService at {DateTime.Now}");
        }
    }
}
