using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            //view models
            return View();
        }
    }
}
