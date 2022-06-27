using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.Mappers;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            var menu = PizzaDb.MenuItems.Select(x => x.ToViewModel()).ToList();

            return View(menu);
        }
    }
}
