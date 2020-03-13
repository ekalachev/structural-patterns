using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Patterns.Shared;

namespace Patterns.Flyweight
{
    public class Car
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
    
    public class Flyweight
    {
        private readonly Car _sharedState;

        public Flyweight(Car car)
        {
            _sharedState = car;
        }

        public void Operation(Car uniqueState)
        {
            var s = JsonConvert.SerializeObject(_sharedState);
            var u = JsonConvert.SerializeObject(uniqueState);
            Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
    }
    
    public class FlyweightFactory
    {
        private readonly Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory(params Car[] args)
        {
            foreach (var elem in args)
            {
                _flyweights.Add(GetKey(elem), new Flyweight(elem));
            }
        }

        private static string GetKey(Car key) => $"{key.Company}_{key.Model}_{key.Color}";

        public Flyweight GetFlyweight(Car sharedState)
        {
            var key = GetKey(sharedState);

            if (_flyweights.TryGetValue(key, out var result))
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
                return result;
            }

            Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
            var flyweight = new Flyweight(sharedState);
            _flyweights.Add(key, flyweight);
            return flyweight;
        }

        public void ListFlyweights()
        {
            var count = _flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            
            foreach (var key in _flyweights.Keys)
            {
                Console.WriteLine(key);
            }
        }
    }


    public class FlyweightPresenter : IPresenter
    {
        private static readonly FlyweightFactory FlyweightFactory = new FlyweightFactory(
            new Car {Company = "Chevrolet", Model = "Camaro2018", Color = "pink"},
            new Car {Company = "Mercedes Benz", Model = "C300", Color = "black"},
            new Car {Company = "Mercedes Benz", Model = "C500", Color = "red"},
            new Car {Company = "BMW", Model = "M5", Color = "red"},
            new Car {Company = "BMW", Model = "X6", Color = "white"});

        public void Run()
        {
            FlyweightFactory.ListFlyweights();

            Operation(new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            Operation(new Car
            {
                Number = "CL678IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            FlyweightFactory.ListFlyweights();
        }

        private static void Operation(Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = FlyweightFactory.GetFlyweight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            flyweight.Operation(car);
        }
    }
}