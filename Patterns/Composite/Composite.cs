using System;
using System.Collections.Generic;
using Patterns.Shared;

namespace Patterns.Composite
{
    public interface IComponent
    {
        string Operation();
    }

    public class Leaf : IComponent
    {
        public string Operation()
        {
            return "Leaf";
        }
    }

    public class Composite : IComponent
    {
        private readonly List<IComponent> _children = new List<IComponent>();
        
        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public string Operation()
        {
            var i = 0;
            var result = "Branch(";

            foreach (var component in _children)
            {
                result += component.Operation();
                if (i != _children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }
            
            return result + ")";
        }
    }

    public class Client
    {
        public void ClientCode(IComponent leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }
    }
    
    public class CompositePresenter : IPresenter
    {
        public void Run()
        {
            var client = new Client();
            
            var leaf = new Leaf();
            client.ClientCode(leaf);
            
            var tree = new Composite();
            var branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            var branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            client.ClientCode(tree);
        }
    }
}