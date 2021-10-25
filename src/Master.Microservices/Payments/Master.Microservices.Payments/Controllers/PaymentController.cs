using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Payments.DataAccess.Models;
using Master.Microservices.Payments.DataAccess.Services;
using Master.Microservices.Payments.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ApiControllerBase<PaymentController>
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(ILog<PaymentController> log, IPaymentService paymentService) : base(log)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<string> TestAsync()
        {
            return await Task.FromResult($"Server called at {DateTime.Now}");
        }

        [HttpPost]
        [Route("CreateOrderPayment")]
        public async Task<bool> CreateOrderPaymentAsync(OrderPaymentViewModel orderPaymentVm)
        {
            var orderPayment = new OrderPayment
            {
                OrderId = orderPaymentVm.OrderId,
                OrderAmount = orderPaymentVm.OrderAmount,
                PaymentStatus = (int)PaymentStatus.UnPaid,
                PaymentType = (int)PaymentType.CashOnDelivery               
            };
            var response = await _paymentService.CreateOrderPaymentAsync(orderPayment);
            return response > -1;
        }
    }
}
