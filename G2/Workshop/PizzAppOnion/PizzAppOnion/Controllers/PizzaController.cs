using Microsoft.AspNetCore.Mvc;
using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Pizza;

namespace PizzAppOnion.API.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public ActionResult Index()
        {
            IEnumerable<PizzaViewModel> pizzas = _pizzaService.GetAllPizzas();

            return View(pizzas);
        }

        public ActionResult Details(int id)
        {
            PizzaViewModel pizza = _pizzaService.GetPizza(id);
            return View(pizza);
        }

        public ActionResult Create()
        {
            PizzaViewModel pizza = new();
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaViewModel pizza)
        {
            _pizzaService.CreatePizza(pizza);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            PizzaViewModel pizza = _pizzaService.GetPizza(id);
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzaViewModel pizza)
        {
            _pizzaService.UpdatePizza(id, pizza);
            return RedirectToAction("Edit", id);
        }

        public ActionResult Delete(int id)
        {
            PizzaViewModel pizza = _pizzaService.GetPizza(id);
            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _pizzaService.DeletePizza(id);
            return RedirectToAction("Index");
        }
    }
}
