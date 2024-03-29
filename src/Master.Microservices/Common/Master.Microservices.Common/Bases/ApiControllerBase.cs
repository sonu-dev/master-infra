﻿using Master.Core.Logging;
using Master.Microservices.Common.Bases.Cqrs;

namespace Master.Microservices.Common.Bases
{
    public abstract class ApiControllerBase<T>
    {
        protected readonly ILog<T> Log;       

        public ApiControllerBase(ILog<T> log)
        {
            Log = log;           
        }
    }
}
