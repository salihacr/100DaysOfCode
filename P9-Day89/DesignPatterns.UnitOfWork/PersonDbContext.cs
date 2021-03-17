using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.UnitOfWork
{
    public class PersonDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // string connStr = @"";
            // optionsBuilder.UseSqlServer(connStr);
        }
        public virtual DbSet<Person> People { get; set; }
    }
}
