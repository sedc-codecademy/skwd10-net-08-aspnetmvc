using Microsoft.AspNetCore.Mvc;

namespace SEDC.Class02.Demo.Controllers
{
    [Route("App/[Action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()   // localhost:port/app/index
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult EmptyRoute()
        {
            return new EmptyResult();
        }

        public IActionResult TakeMeToHomePage()
        {
            return RedirectToAction("Index", "Home");
        }


        public IActionResult JsonResult()
        {
            var user = new { Id = 1, FullName = "Martin Panovski", Age = 28 };
            return new JsonResult(user);
        }

        public IActionResult TakeMeToUserPage()
        {
            return RedirectToAction("Index", "User");
        }

    }
}
