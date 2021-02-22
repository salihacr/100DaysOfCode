using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Crud.Models
{
    public class EmployeeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server =SALIH; Database=employee-crud-db; Trusted_Connection = True";
            optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
