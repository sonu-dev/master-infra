namespace Master.Learning.DesignPatterns.Behavioral
{
    public class TemplateMethodClient
    {       
        public void Execute()
        {
            var templateMethodDerived = new TemplateMethodDerived();
            templateMethodDerived.TemplateMethod();           
        }
    }
}
