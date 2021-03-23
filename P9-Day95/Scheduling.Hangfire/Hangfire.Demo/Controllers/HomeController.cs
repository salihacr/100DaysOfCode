using Microsoft.AspNetCore.Mvc;
using System;

namespace Hangfire.Demo.Controllers
{
    public class HomeController : Controller
    {
        [Obsolete]
        public IActionResult Index()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-And-Forget Jobs tetiklendi"));
            Hangfire.RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring jobs tetiklendi!"), Hangfire.Cron.MonthInterval(1));
            Hangfire.BackgroundJob.Schedule(() => Console.WriteLine("Delayed jobs tetiklendi!"), TimeSpan.FromSeconds(10));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
