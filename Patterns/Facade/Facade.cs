using System;
using Patterns.Shared;

namespace Patterns.Facade
{
    public class Facade
    {
        private readonly Subsystem1 _subsystem1;

        private readonly Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            _subsystem1 = subsystem1;
            _subsystem2 = subsystem2;
        }
        
        public string Operation()
        {
            var result = "Facade initializes subsystems:\n";
            result += _subsystem1.Operation1();
            result += _subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += _subsystem1.OperationN();
            result += _subsystem2.OperationZ();
            return result;
        }
    }
    
    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string OperationN()
        {
            return "Subsystem1: Go!\n";
        }
    }
    
    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string OperationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }

    public class FacadePresenter : IPresenter
    {
        public void Run()
        {
            var subsystem1 = new Subsystem1();
            var subsystem2 = new Subsystem2();

            var facade = new Facade(subsystem1, subsystem2);
            var res = facade.Operation();
            
            Console.Write(res);
        }
    }
}