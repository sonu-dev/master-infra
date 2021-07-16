using Master.Learning.DesignPatterns.Behavioral;
using Master.Learning.DesignPatterns.Creational;
using System;

namespace Master.Learning.DesignPatterns
{
    class Program
    {
       public static void Main(string[] args)
        {
            #region Creational

            // Singleton
            var singletonClient = new SingletonClient();
            singletonClient.Execute();
            #endregion

            #region Behavioral

            // TemplateMethod
            var templateMethodClient = new TemplateMethodClient();
            templateMethodClient.Execute();
            #endregion           

            Console.ReadKey();
        }
    }
}
