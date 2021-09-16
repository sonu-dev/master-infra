using Master.Core.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Common.Bases
{
    /// <summary>
    /// CQRS Base Handler <br/>
    /// Ref: https://www.ezzylearning.net/tutorial/implement-cqrs-pattern-in-asp-net-core-5 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>      
        where TResponse : class
    {
        #region Data Members
        protected ILog<TRequest> Log;
        #endregion

        #region Constructotrs
        public RequestHandlerBase(ILog<TRequest> log)
        {
            Log = log;
        }
        #endregion

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            Log.Debug($"Requesting for {typeof(TRequest).Name}");
            return await ProcessAsync(request);
        }

        public abstract Task<TResponse> ProcessAsync(TRequest request);        
    }
}
