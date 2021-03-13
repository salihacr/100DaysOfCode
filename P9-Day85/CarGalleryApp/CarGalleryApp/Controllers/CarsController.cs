﻿using CarGalleryApp.Models;
using CarGalleryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGalleryApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarService carService;
        public CarsController(CarService carService)
        {
            this.carService = carService;
        }
        // GET: CarsController
        public ActionResult Index()
        {
            return View(carService.Get());
        }

        // GET: Cars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                carService.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var car = carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                carService.Update(id, car);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(car);
            }
        }
        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                var car = carService.Get(id);

                if (car == null)
                {
                    return NotFound();
                }

                carService.Remove(car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
