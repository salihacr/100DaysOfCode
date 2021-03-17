using System.Collections.Generic;

namespace DesignPatterns.UnitOfWork
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetPersons();
    }
}
