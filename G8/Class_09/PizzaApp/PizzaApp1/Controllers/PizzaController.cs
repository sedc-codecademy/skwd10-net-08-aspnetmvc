using Microsoft.AspNetCore.Mvc;
using PizzaApp.Application.Services;
using PizzaApp.Application.ViewModel.Pizza;

namespace PizzaApp1.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            var pizzas = pizzaService.GetAllPizza();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            var pizza = pizzaService.GetPizza(id);
            return View(pizza);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pizza = pizzaService.GetPizza(id);
            return View(pizza);
        }
        [HttpPost]
        public IActionResult Edit(int id, PizzaViewModel model)
        {
            try
            {
                pizzaService.EditPizza(model, id);
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var pizzaSize = pizzaService.GetPizzaSizes().ToList();
            ViewBag.pizzaSize = pizzaSize;
            ViewData.Add("PizzaSize1", pizzaService);

            return View();
        }

        // order/{orderId:int}/pizza/{pizzaId}/toppings/{toppingId:id}
        //order/1/pizza/1/toppings/1

        [HttpPost]
        public IActionResult Create(CreatePizzaViewModel model)
        {
            try
            {
                pizzaService.CreatePizza(model);
            }
            catch
            {
                var pizzaSize = pizzaService.GetPizzaSizes().ToList();
                ViewBag.pizzaSize = pizzaSize;
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("Pizza/Delete/{id}")]
        public IActionResult GetDeletePage(int id)
        {
            var pizza = pizzaService.GetPizza(id);

            return View(pizza);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            pizzaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
