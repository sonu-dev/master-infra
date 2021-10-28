using Dapper;
using Master.Core.Logging;
using Master.Microservices.Common.Bases;
using Master.Microservices.Common.Dapper;
using Master.Microservices.Payments.DataAccess.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Master.Microservices.Payments.DataAccess.Services
{
    public class PaymentService : ServiceBase<PaymentService>, IPaymentService
    {
        private readonly DapperContext _dbContext;
        public PaymentService(ILog<PaymentService> log, DapperContext dbContext) : base(log)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOrderPaymentAsync(OrderPayment order)
        {
            var query = "insert into [Payments].[OrderPayment] ([OrderId],[OrderAmount],[PaymentType],[Status],[CreatedBy],[CreateTime],[UpdateTime]) VALUES(@OrderId,@OrderAmount,@PaymentType,@Status,@CreatedBy,@CreateTime,@UpdateTime)";

            var parameters = new DynamicParameters();
            parameters.Add("OrderId", order.OrderId, DbType.Int32);
            parameters.Add("OrderAmount", order.OrderAmount, DbType.Decimal);
            parameters.Add("PaymentType", order.PaymentType, DbType.Int32);
            parameters.Add("Status", order.PaymentStatus, DbType.Int32);
            parameters.Add("CreatedBy", order.CreatedBy, DbType.Int32);
            parameters.Add("CreateTime", order.CreateTime, DbType.DateTime);
            parameters.Add("UpdateTime", order.UpdateTime, DbType.DateTime);

            var result = -1;
            using var connection = _dbContext.CreateConnection();
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        result = await connection.ExecuteAsync(query, parameters, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
            return result;
        }
    }
}
