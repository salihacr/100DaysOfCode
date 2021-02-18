using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {

            IVehicle vehicle = new Submarine();
            VehicleController salih = new VehicleController(vehicle);
            salih.FireToEnemy();
            salih.MoveToSomewhere();

            Console.ReadKey();
        }
    }

    public interface IVehicle
    {
        void Fire();
        void Move();
    }

    public class Plane : IVehicle
    {
        public void Fire()
        {
            Console.WriteLine("Fire from plane");
        }

        public void Move()
        {
            Console.WriteLine("Plane on the move");
        }
    }
    public class Tank : IVehicle
    {
        public void Fire()
        {
            Console.WriteLine("Fire from Tank");
        }

        public void Move()
        {
            Console.WriteLine("Tank on the move");
        }
    }
    public class Submarine : IVehicle
    {
        public void Fire()
        {
            Console.WriteLine("Fire from Submarine");
        }

        public void Move()
        {
            Console.WriteLine("Submarine on the move");
        }
    }
    public class VehicleController
    {
        IVehicle _vehicle;
        public VehicleController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void FireToEnemy()
        {
            _vehicle.Fire();
        }
        public void MoveToSomewhere()
        {
            _vehicle.Move();
        }
    }
}
