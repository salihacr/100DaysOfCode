using BlazorWebAPI.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAPI.Server.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        // DbSet's (Tables)
        public DbSet<User> Users { get; set; }
    }
}
