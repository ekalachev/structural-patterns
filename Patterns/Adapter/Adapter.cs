using System;
using Patterns.Shared;

namespace Patterns.Adapter
{
    public interface ITarget
    {
        string GetRequest();
    }

    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }
    
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{_adaptee.GetSpecificRequest()}'";
        }
    }

    
    public class AdapterPresenter : IPresenter
    {
        public void Run()
        {
            var adaptee = new Adaptee();
            
            ITarget target = new Adapter(adaptee);

            var result = target.GetRequest();
            Console.WriteLine(result);
        }
    }
}