using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{

    // buraya prefix url verip tüm metotların bu url altında olacağını belirtebiliyoruz
    // [Route("sayfa")] bunu aktif edersek tüm action lara /sayfa/ url şeklinde gidebiliriz
    public class AttributeRouteController : Controller
    {
        [Route("makale")]
        // url : /makale
        public IActionResult Index()
        {
            return View();
        }
        // url : /makale/baslik
        [Route("makale/{baslik}")]
        public IActionResult Index(string baslik)
        {
            ViewBag.Title = baslik;
            return View();
        }
        // url : makale/baslik/detail
        [Route("makale/{baslik}/detail")]
        public ActionResult Detail(string baslik)
        {
            ViewBag.Title = baslik;
            return View();
        }
    }
}
