namespace DesignPatterns.Decorator.RepositoryDecorator
{
    public interface IRepository<T>
    {
        public T Get(int id);
        public T GetAll();
        public void Add(T model);
        public void Update(T model);
        public void Delete(T model);
    }
}