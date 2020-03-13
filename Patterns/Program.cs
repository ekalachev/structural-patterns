using System;
using Patterns.Adapter;
using Patterns.Bridge;
using Patterns.Composite;
using Patterns.Decorator;
using Patterns.Facade;
using Patterns.Flyweight;
using Patterns.Proxy;

namespace Patterns
{
    public static class Program
    {
        private static void Main()
        {
            var presenter = new DecoratorPresenter();
            // var presenter = new ProxyPresenter();
            // var presenter = new BridgePresenter();
            // var presenter = new CompositePresenter();
            // var presenter = new FlyweightPresenter();
            // var presenter = new AdapterPresenter();
            // var presenter = new FacadePresenter();

            presenter.Run();
        }
    }
}