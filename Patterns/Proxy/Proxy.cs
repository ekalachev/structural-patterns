using System;
using Patterns.Shared;

namespace Patterns.Proxy
{
    public interface IComponent
    {
        void Request();
    }
    
    public class Component : IComponent
    {
        public void Request()
        {
            Console.WriteLine("Component: Handling Request.");
        }
    }
    
    public class Proxy : IComponent
    {
        public void Request()
        {
            if (!CheckAccess()) return;
            
            var component = new Component();
            component.Request();

            LogAccess();
        }

        private static bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");

            return true;
        }

        private static void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }
    
    public class Client
    {
        public void ClientCode(IComponent component)
        {
            component.Request();
        }
    }

    public class ProxyPresenter : IPresenter
    {
        public void Run()
        {
            var client = new Client();
            
            var component = new Component();
            client.ClientCode(component);

            Console.WriteLine();
            
            var proxy = new Proxy();
            client.ClientCode(proxy);
        }
    }
}