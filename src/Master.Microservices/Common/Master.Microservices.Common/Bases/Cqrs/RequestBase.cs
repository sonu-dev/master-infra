using MediatR;

namespace Master.Microservices.Common.Bases.Cqrs
{
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
    }
}
