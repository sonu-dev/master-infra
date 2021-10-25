using MassTransit;
using Master.Microservices.Common.RabbitMq.Constants;
using Master.Microservices.Common.RabbitMq.Producer;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Master.Microservices.Common.RabbitMq.Host
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterMassTransit(this IServiceCollection services)
        {
            
        }
    }
}
