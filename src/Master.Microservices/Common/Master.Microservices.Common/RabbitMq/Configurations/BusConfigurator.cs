using MassTransit;
using MassTransit.RabbitMqTransport;
using Master.Microservices.Common.RabbitMq.Constants;
using System;

namespace Master.Microservices.Common.RabbitMq.Configurations
{
    public class BusConfigurator
    {
       public static void ConfigureBus(IRabbitMqBusFactoryConfigurator configurator)
        {
            configurator.Host(new Uri(RabbitMqConfigurations.RabbitMqUri), h =>
            {
                h.Username(RabbitMqConfigurations.UserName);
                h.Password(RabbitMqConfigurations.Password);
            });
        }
    }
}
