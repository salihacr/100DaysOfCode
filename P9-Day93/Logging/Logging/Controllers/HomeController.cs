using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Information Message...");
            return View();
        }

        public IActionResult Warning()
        {
            _logger.LogWarning("Warning Message...");
            return View();
        }
        public IActionResult Error()
        {
            _logger.LogError("Error Message...");
            return View();
        }
    }
}
