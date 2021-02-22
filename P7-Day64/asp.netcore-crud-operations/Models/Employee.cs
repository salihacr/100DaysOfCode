using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_Crud.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
    }
}
