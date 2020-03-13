using System;
using Patterns.Shared;

namespace Patterns.Decorator
{
    public interface IComponent
    {
        string Operation();
    }
    
    public class Component : IComponent
    {
        public string Operation()
        {
            return "ConcreteComponent";
        }
    }

    public class DecoratorA : IComponent
    {
        private readonly IComponent _comp;

        public DecoratorA(IComponent comp)
        {
            _comp = comp;
        }
        
        public string Operation()
        {
            return $"ConcreteDecoratorA_{_comp.Operation()}";
        }
    }
    
    public class DecoratorB : IComponent
    {
        private readonly IComponent _comp;

        public DecoratorB(IComponent comp)
        {
            _comp = comp;
        }

        public string Operation()
        {
            return $"ConcreteDecoratorB_{_comp.Operation()}";
        }
    }
    
    public class Client
    {
        public void ClientCode(IComponent component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    public class DecoratorPresenter : IPresenter
    {
        public void Run()
        {
            
            var client = new Client();

            var simple = new Component();
            client.ClientCode(simple);
            Console.WriteLine();

            var decorator1 = new DecoratorA(simple);
            var decorator2 = new DecoratorB(decorator1);
            client.ClientCode(decorator2);
        }
    }
}