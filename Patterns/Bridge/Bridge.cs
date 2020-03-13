using System;
using Patterns.Shared;

namespace Patterns.Bridge
{
    public class Abstraction
    {
        protected readonly IImplementation Implementation;
        
        public Abstraction(IImplementation implementation)
        {
            Implementation = implementation;
        }
        
        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" + 
                   Implementation.OperationImplementation();
        }
    }
    
    public class ExtendedAbstraction : Abstraction
    {
        public ExtendedAbstraction(IImplementation implementation) : base(implementation)
        {
        }
        
        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                   base.Implementation.OperationImplementation();
        }

        public void OneMoreOperation()
        {
            
        }
    }

    public interface IImplementation
    {
        string OperationImplementation();
    }
    
    public class ImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform A.\n";
        }
    }

    public class ImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: The result in platform B.\n";
        }
    }

    public class Client
    {
        public void ClientCode(Abstraction abstraction)
        {
            Console.Write(abstraction.Operation());
        }
    }
    
    public class BridgePresenter : IPresenter
    {
        public void Run()
        {
            var client = new Client();
            
            var abstraction = new Abstraction(new ImplementationA());
            client.ClientCode(abstraction);
            
            Console.WriteLine();
            
            abstraction = new ExtendedAbstraction(new ImplementationB());
            client.ClientCode(abstraction);
        }
    }
}