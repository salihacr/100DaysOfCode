namespace DesignPatterns.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDbContext _context;
        public IPersonRepository PersonRepository { get; private set; }
        public UnitOfWork(PersonDbContext context)
        {
            _context = context;
            PersonRepository = new PersonRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
