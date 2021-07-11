﻿using System;
using System.Threading.Tasks;

namespace Master.Common.Bases
{
    public interface IClient
    {
        Task RunAsync(IServiceProvider serviceProvider = null);
    }
}
