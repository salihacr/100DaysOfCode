using System.Collections.Generic;

namespace DesignPatterns.UnitOfWork
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext context) : base(context)
        {

        }
        public PersonDbContext PersonDbContext
        {
            get { return _context as PersonDbContext; }
        }
        public IEnumerable<Person> GetPersons()
        {
            return PersonDbContext.People;
        }
    }
}
