using System;
namespace DesignPatterns.Decorator.RepositoryDecorator
{
    // Herhangi bir kayıt güncellendiğinde kim tarafından hangi tarihte yapıldığına dair yöneticiye mail gönderilsin
    //ConcreteDecorator
    class SendMailRepositoryDecorator<T> : DecoratorRepository<T> where T : class
    {
        readonly IRepository<T> _repository;
        public SendMailRepositoryDecorator(IRepository<T> repository) : base(repository)
        {
            _repository = repository;
        }
        public override void Update(T model)
        {
            base.Update(model);
            Console.WriteLine($"{DateTime.Now} | Yöneticiye mail gönderildi...");
        }
    }
}
