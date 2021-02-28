using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modal_Jquery_CRUD.Models
{
    public class TransactionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connection = @"Server=SALIH; Database=transaction-db; Trusted_Connection=True; MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
