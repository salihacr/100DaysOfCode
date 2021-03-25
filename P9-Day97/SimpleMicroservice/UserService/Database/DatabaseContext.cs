using Microsoft.EntityFrameworkCore;
using UserService.Database.Entities;

namespace UserService.Database
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SALIH; Initial Catalog=microservice-db; Integrated Security=True;");
        }
        public DbSet<User> Users { get; set; }
    }
}
