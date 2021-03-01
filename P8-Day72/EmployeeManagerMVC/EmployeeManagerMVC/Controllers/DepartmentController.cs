using EmployeeManagerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public DepartmentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Departments.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            return id == 0 ? View() : View(await _dbContext.Departments.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.Id == 0)
                {
                    _dbContext.Add(department);
                }
                else
                {
                    _dbContext.Update(department);
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if (id == null || department == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Departments.Remove(department);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}
