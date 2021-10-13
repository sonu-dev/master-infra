using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Common.Bases.Cqrs
{
    public class MediatorPublisher: IMediatorPublisher
    {
        #region DataMembers
        private readonly IMediator _mediator;
        #endregion

        #region Constructors
        public MediatorPublisher(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Public Methods
        public async Task<TResponse> PublishAsync<TResponse>(IRequest<TResponse> request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
        #endregion
    }

    public interface IMediatorPublisher
    {
        public Task<TResponse> PublishAsync<TResponse>(IRequest<TResponse> request);
    }
}
