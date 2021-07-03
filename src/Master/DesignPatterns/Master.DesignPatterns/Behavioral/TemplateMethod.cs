using System;
using System.Collections.Generic;
using System.Text;

namespace Master.DesignPatterns.Behavioral
{
    /// <summary>
    /// Template Method is a behavioral design pattern that allows you to defines a skeleton of an algorithm in a base class and let subclasses override the steps without changing the overall algorithm’s structure.
    /// The Template Method pattern is quite common in C# frameworks. Developers often use it to provide framework users with a simple means of extending standard functionality using inheritance.
    /// </summary>
    public abstract class TemplateMethodBase
    {
        protected Serilog.ILogger Log;
        public TemplateMethodBase(Serilog.ILogger log)
        {
            Log = log;
        }
        public void TemplateMethod()
        {            
            BaseOperation1();
            BaseOperation2();
            RequiredOperation1();
            RequiredOperation2();
        }
        public void BaseOperation1()
        {
            Log.Debug("Call BaseOperation1...");
        }

        public void BaseOperation2()
        {
            Log.Debug("Call BaseOperation2...");
        }

        public abstract void RequiredOperation1();
        public abstract void RequiredOperation2();
    }

    public class TemplateMethodDerived : TemplateMethodBase
    {       
        public TemplateMethodDerived(Serilog.ILogger log) : base(log)
        {
        }
        public override void RequiredOperation1()
        {
            Log.Debug("Call RequiredOperation1...");
        }

        public override void RequiredOperation2()
        {
            Log.Debug("Call RequiredOperation2...");
        }
    }  
}
