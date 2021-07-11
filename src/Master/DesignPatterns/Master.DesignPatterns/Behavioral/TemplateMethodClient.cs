using Master.Common.Bases;
using Master.Common.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Master.DesignPatterns.Behavioral
{
    public class TemplateMethodClient : ClientBase<TemplateMethodClient>
    {
        public TemplateMethodClient(ILog<TemplateMethodClient> log, IServiceProvider serviceProvider): base(log)
        {
        }

        public override Task ExecuteAsync(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetService(typeof(ILog<TemplateMethodDerived>)) as ILog<TemplateMethodDerived>;
            var templateMethodDerived = new TemplateMethodDerived(logger);
            templateMethodDerived.TemplateMethod();
            return Task.CompletedTask;
        }
    }
}
