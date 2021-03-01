using EmployeeManagerMVC.Models;
using EmployeeManagerMVC.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _dbContext;
        [Obsolete]
        private readonly IHostingEnvironment _environment;

        [Obsolete]
        public EmployeeController(AppDbContext dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Employees.Include(x => x.Department).ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> AddOrEdit(string id = "")
        {

            var employee = await _dbContext.Employees.FindAsync(id);
            var departments = await _dbContext.Departments.ToListAsync();
            ViewBag.Departments = departments;
            var viewModel = new EmployeeViewModel()
            {
                Department = departments,
                Employee = employee
            };
            return id == "" ? View(new EmployeeViewModel() { Department = departments, Employee = new Employee() { Image = "" } }) : View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(IFormFile file, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    employee.Image = await SaveImage(file);
                }

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
        public async Task<string> SaveImage(IFormFile file)
        {
            string fileName = "";
            if (file != null)
            {
                fileName = Guid.NewGuid().ToString();
                fileName += Path.GetExtension(file.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{fileName}");
                using var stream = new FileStream(imagePath, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _dbContext.Employees.FindAsync(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
