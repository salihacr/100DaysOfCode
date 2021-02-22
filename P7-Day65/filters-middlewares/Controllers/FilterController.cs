using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters_And_Middleware.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters_And_Middleware.Controllers
{
    public class FilterController : Controller
    {
        [CustomFilter]
        public IActionResult Index()
        {
            return View();
        }
        [HandleException]
        public IActionResult TestErrorPage()
        {
            throw new Exception("Some exception occured");
            return View();
        }
    }
}
