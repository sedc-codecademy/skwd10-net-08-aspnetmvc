using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzaApp.Web.Controllers
{
    [Route("app")]
    public class PizzaController : Controller
    {
        [HttpGet("all")]
        public IActionResult Index()
        {
            var pizzas = StaticDb.Pizzas;
            if (pizzas == null)
                return NotFound();
            return View(pizzas);
        }

        [HttpGet("pizza-details/{id}")]
        public IActionResult Details(int? id)
        {
            var pizza = StaticDb.Pizzas.SingleOrDefault(x => x.Id == id);
            if (pizza == null)
                return NotFound();
            return View(pizza);
        }
    }
}
