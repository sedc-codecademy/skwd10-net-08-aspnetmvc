using Microsoft.AspNetCore.Mvc;
using PizzaApp1.Models;
using System.Diagnostics;

namespace PizzaApp1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug("Sega sum vo home");
            _logger.LogInformation("");
            _logger.LogWarning("");
            _logger.LogError("");
            _logger.LogCritical("");
        }

        public IActionResult Index()
        {
            _logger.LogDebug("Sega e povikan index home");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}