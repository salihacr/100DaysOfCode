using System;
using System.Linq;

namespace DesignPatterns.UnitOfWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new PersonDbContext()))
            {
                unitOfWork.PersonRepository.Add(new Person() { Id = 1, Name = "Salih", Lastname = "Kral" });
                unitOfWork.PersonRepository.Add(new Person() { Id = 2, Name = "ABC", Lastname = "Kral" });
                unitOfWork.PersonRepository.Add(new Person() { Id = 3, Name = "DEF", Lastname = "Kral" });

                Person[] people = unitOfWork.PersonRepository.GetPersons().ToArray();
            }
            Console.ReadKey();
        }
    }
}
