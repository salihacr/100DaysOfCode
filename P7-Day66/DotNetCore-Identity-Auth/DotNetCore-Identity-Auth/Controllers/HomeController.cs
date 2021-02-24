using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_Identity_Auth.Controllers
{
    // Tum metodların auth istemesine sebep olur
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]// metoda göre özelleştirebiliriz.
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult PrivatePage()
        {
            return View();
        }
    }
}
