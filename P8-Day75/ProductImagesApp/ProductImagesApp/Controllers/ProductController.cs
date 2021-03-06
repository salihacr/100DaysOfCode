using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductImagesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductImagesApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _dbContext;
        [Obsolete]
        private readonly IHostingEnvironment _environment;

        [Obsolete]
        public ProductController(MyDbContext dbContext, IHostingEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Products.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> AddOrEdit(string id = "")
        {

            var product = await _dbContext.Products.FindAsync(id);
            var images = await _dbContext.ProductImages.Where(x => x.ProductId == id).ToListAsync();
            ViewBag.ProductImages = images;
            var viewModel = new ProductImageViewModel()
            {
                Product = product,
                ProductImages = images
            };
            var emptyViewModel = new ProductImageViewModel()
            {
                ProductImages = images,
                Product = new Product() { MainImage = "" }
            };
            return id == "" ? View(emptyViewModel) : View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit([FromForm] Product product, IFormFile mainFile, List<IFormFile> files)
        {
            var productImages = new List<ProductImage>();
            if (ModelState.IsValid)
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        string path = await SaveImage(file);
                        var productImage = new ProductImage() { ImagePath = path };
                        productImages.Add(productImage);
                    }
                }
                if (mainFile != null)
                {
                    product.MainImage = await SaveImage(mainFile);
                }
                product.ProductImages = productImages;

                if (product.ProductId == null)
                {
                    product.ProductId = Guid.NewGuid().ToString();
                    _dbContext.Add(product);
                }
                else
                {
                    _dbContext.Update(product);
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
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
            var product = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
