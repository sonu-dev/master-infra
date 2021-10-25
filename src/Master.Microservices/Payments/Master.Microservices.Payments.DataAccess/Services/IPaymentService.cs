using Master.Microservices.Payments.DataAccess.Models;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.DataAccess.Services
{
   public interface IPaymentService
    {
       Task<int> CreateOrderPaymentAsync(OrderPayment order);
    }
}
