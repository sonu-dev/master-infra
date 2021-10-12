using Master.Core.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Common.Bases.Cqrs
{
    /// <summary>
    /// CQRS Base Handler <br/>
    /// Ref: https://www.ezzylearning.net/tutorial/implement-cqrs-pattern-in-asp-net-core-5 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class RequestHandlerBase<THandler, TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>      
        where TResponse : class
    {
        #region Data Members
        protected ILog<THandler> Log;
        #endregion

        #region Constructotrs
        public RequestHandlerBase(ILog<THandler> log)
        {
            Log = log;
        }
        #endregion

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            Log.Debug($"Executing CQRS Handler: {typeof(THandler).Name}");
            return await ProcessAsync(request);
        }

        public abstract Task<TResponse> ProcessAsync(TRequest request);        
    }
}
