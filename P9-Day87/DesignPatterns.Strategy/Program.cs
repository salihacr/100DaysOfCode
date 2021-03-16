using System;

namespace DesignPatterns.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {

            SpecialProduction specialProduction = new SpecialProduction();
            MassProduction massProduction = new MassProduction();
            ToOrderProduction toOrderProduction = new ToOrderProduction();

            Producer produce1 = new Producer(specialProduction);
            Producer produce2 = new Producer(massProduction);
            Producer produce3 = new Producer(toOrderProduction);


            Console.ReadKey();
        }
    }
    class Car
    {
        public Car(string productionType)
        {
            Console.WriteLine($"The car was produced as a {productionType} production.");
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public float Km { get; set; }
    }
    // Strategy Pattern
    abstract class Strategy
    {
        public abstract Car Produce();
    }

    // Production Types (Strategies)
    class MassProduction : Strategy
    {
        public override Car Produce()
        {
            return new Car("Mass");
        }
    }
    class SpecialProduction : Strategy
    {
        public override Car Produce()
        {
            return new Car("Special");
        }
    }
    class ToOrderProduction : Strategy
    {
        public override Car Produce()
        {
            return new Car("To Order");
        }
    }

    // Producer
    class Producer
    {
        public Producer(Strategy strategy)
        {
            strategy.Produce();
        }
    }
}
