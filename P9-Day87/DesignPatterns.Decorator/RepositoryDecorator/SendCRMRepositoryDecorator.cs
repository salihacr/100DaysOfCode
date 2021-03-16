using System;

namespace DesignPatterns.Decorator.RepositoryDecorator
{
    //ConcreteDecorator
    //Herhangi bir kayıt silindiğinde veya güncellendiğinde CRM veritabanına API’lar aracılığıyla bağlanılarak aynı değişiklikler oraya da yansıtılsın
    class SendCRMRepositoryDecorator<T> : DecoratorRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public SendCRMRepositoryDecorator(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }
        public override void Delete(T model)
        {
            base.Delete(model);
            Console.WriteLine("Kaydın silinmesi CRM veritabanına işlendi.");
        }
        public override void Update(T model)
        {
            base.Update(model);
            Console.WriteLine("Kaydın güncellenmesi CRM veritabanına işlendi.");
        }
    }
}
