﻿using Master.Core.Host.Bases;
using Master.Core.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Master.Microservices.Orders.Host.HostedServices
{
    public class OrderHostedService : HostedServiceBase<OrderHostedService>
    {
        public OrderHostedService(ILog<OrderHostedService> log, IServiceProvider serviceProvider): base(log, serviceProvider)
        {
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
