using Microsoft.AspNetCore.Mvc;
using SEDC.Class03.Demo.Models.Domain;
using System.Diagnostics;

namespace SEDC.Class03.Demo.Controllers
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
            return View();
        }


        public IActionResult GetUserById(int id)
        {
            User user = StaticDb.Users.SingleOrDefault(x => x.Id == id);
            if(user == null)
                return NotFound();
            return View(user);
        }


        public IActionResult GetUserByName(string firstName, string lastName)
        {
            User user = StaticDb
                        .Users
                        .FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
            if (user == null)
                return NotFound();
            return View("GetUserById", user);
        }


        public IActionResult DisplayName(string firstName)
        {
            User user = StaticDb
                        .Users
                        .FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
            
            // Sending primitive type data to the view
            ViewData.Add("FirstName", firstName);

            // Sending complex type data to the view
            ViewData.Add("User", user);

            return View();
        }

        public IActionResult DisplayData(int id) 
        {
            User user = StaticDb.Users.SingleOrDefault(x => x.Id == id);
            ViewBag.User = user;
            ViewBag.TodaysDate = DateTime.Now.ToShortDateString();
            if (user == null)
                return NotFound();
            return View();
        }
    }
}