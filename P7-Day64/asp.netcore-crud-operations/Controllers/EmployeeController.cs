using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore_Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _dbContext;

        public EmployeeController(EmployeeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Employees.ToListAsync();
            return View(model);
        }

        public IActionResult AddOrEdit(string id = "")
        {
            return id == "" ? View() : View(_dbContext.Employees.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id == null)
                {
                    employee.Id = Guid.NewGuid().ToString();
                    _dbContext.Add(employee);
                }
                else
                {
                    _dbContext.Update(employee);
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
