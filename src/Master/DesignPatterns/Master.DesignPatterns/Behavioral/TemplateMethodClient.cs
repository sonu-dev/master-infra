using Master.Common.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Master.DesignPatterns.Behavioral
{
   public class TemplateMethodClient : ClientBase<TemplateMethodClient>
    {
        public TemplateMethodClient(): base()
        {
        }

        public override Task ExecuteAsync()
        {
            var templateMethodDerived = new TemplateMethodDerived(Log);
            templateMethodDerived.TemplateMethod();
            return Task.CompletedTask;
        }
    }
}
