using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session_Cookie.Models;

namespace Session_Cookie.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        static string username = "salih";
        static string password = "12345";
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(User user)
        {

            if (ModelState.IsValid && user.Username == username && user.Password == password)
            {
                user.UserId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("UserId", user.UserId);
                return View("Success", user);
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Account";
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index");
        }
    }
    // Custom Session Extension Helper Class
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set(key, JsonSerializer.SerializeToUtf8Bytes(value));
        }
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.Get(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}
