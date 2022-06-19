using Microsoft.AspNetCore.Mvc;
using MVCTestRecap.Database;
using MVCTestRecap.Models.Mappers;
using MVCTestRecap.Models.ViewModels;

namespace MVCTestRecap.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<PizzaListViewModel> pizzaListViewModel = PizzaDb.PIZZAS.Select(x => x.ToPizzaListViewModel()).ToList();
            ViewData["PizzaCount"] = pizzaListViewModel.Count;

            ViewBag.AllPizzas = pizzaListViewModel;
            return View(pizzaListViewModel);
        }

        [HttpGet]
        [Route("pizza-details")]
        public IActionResult Details([FromQuery] int id)
        {
            PizzaDetailsViewModel pizzaDetailsViewModel = PizzaDb.PIZZAS.FirstOrDefault(x => x.Id == id).ToPizzaDetailsViewModel();
            ViewData["Message"] = "The pizza is great!";
            return View(pizzaDetailsViewModel);
        }
    }
}
