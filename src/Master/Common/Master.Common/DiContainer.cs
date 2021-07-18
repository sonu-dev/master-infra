using Microsoft.Extensions.DependencyInjection;
using System;

namespace Master.Core.Common
{
    public class DiContainer
    {
        private static IServiceProvider _serviceProvider;

        public static void Setup(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T Resolve<T>()
        {
            if(_serviceProvider == null)
            {
                throw new Exception("Service provider is null");
            }
            return _serviceProvider.GetService<T>();           
        }
    }
}
