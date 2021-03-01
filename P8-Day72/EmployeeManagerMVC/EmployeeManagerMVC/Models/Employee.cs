using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerMVC.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public float Salary { get; set; }
        public string Image { get; set; }
        public Department Department { get; set; }
        public int DepartmentId {get;set;}
    }
}
