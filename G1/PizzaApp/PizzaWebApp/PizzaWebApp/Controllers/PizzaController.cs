using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.Mappers;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            var pizzas = PizzaDb.Pizzas.Select(x => x.ToViewModel()).ToList();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            var pizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza == null)
            {
                throw new Exception($"Pizza with Id {id} not found");
            }

            return View(pizza.ToViewModel());
        }
    }
}
