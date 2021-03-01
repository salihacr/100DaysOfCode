using EmployeeManager_Mvc_Modal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager_Mvc_Modal.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Department> Department { get; set; }
        public Employee Employee { get; set; }
    }
}
