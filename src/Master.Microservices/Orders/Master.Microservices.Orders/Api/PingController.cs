using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController
    {
        [HttpGet]
        public async Task<string> PingAsync()
        {
            return await Task.FromResult($"Ping OrderService at {DateTime.Now}");
        }
    }
}
