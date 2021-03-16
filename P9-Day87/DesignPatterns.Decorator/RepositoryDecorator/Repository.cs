using System;

namespace DesignPatterns.Decorator.RepositoryDecorator
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Add(T model)
        {
            Console.WriteLine("Model eklendi.");
        }

        public void Delete(T model)
        {
            Console.WriteLine("Model silindi.");
        }

        public T Get(int id)
        {
            Console.WriteLine("Id bazlı veri çekildi.");
            return null;
        }

        public T GetAll()
        {
            Console.WriteLine("Tüm veriler çekildi.");
            return null;
        }

        public void Update(T model)
        {
            Console.WriteLine("Model güncellendi.");
        }
    }
}
