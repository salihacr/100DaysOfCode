using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator.RepositoryDecorator
{
    //Decorator
    public class DecoratorRepository<T> : IRepository<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public DecoratorRepository(IRepository<T> repository)
        {
            _repository = repository;
        }
        virtual public void Add(T model)
        {
            _repository.Add(model);
        }
        virtual public void Delete(T model)
        {
            _repository.Delete(model);
        }
        virtual public T Get(int id)
        {
            return _repository.Get(id);
        }
        virtual public T GetAll()
        {
            return _repository.GetAll();
        }
        virtual public void Update(T model)
        {
            _repository.Update(model);
        }
    }
}
