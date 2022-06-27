using Microsoft.AspNetCore.Mvc;
using PizzaApp1.Models.Domain;
using PizzaApp1.Models.Mapper;
using PizzaApp1.Models.ViewModel;

namespace PizzaApp1.Controllers
{
    // order
    public class OrderController : Controller
    {
        // default view resolving
        // views/[controller]/[action].cshtml
        // views/shared/[action].cshtml

        // ~/views/.../ .cshtml

        //public IActionResult Index()
        //{
        //    return View("~/Views/Home/Index.cshtml");
        //}

        public IActionResult Index()
        {
            var orders = PizzaAppDb.Orders.ToList();
            return View(orders);
        }
        //order/details/[1,2,3...]
        public IActionResult Details(int id)
        {
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return new EmptyResult();
            }
            return View(order);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var pizzas = PizzaAppDb.Pizzas.ToList();
            ViewBag.Pizzas = pizzas;
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model)
        {
            var selectedPizzas = model.Pizzas.Where(x => x.IsSelected);

            var orderedPizzas = new List<Pizza>();
            foreach (var pizza in selectedPizzas)
            {
                var pizzaModel = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == pizza.PizzaId);
                if (pizzaModel == null)
                    throw new Exception("Pizza doesn't exist");


                Enumerable.Range(0, pizza.NumberOfPizzas).ToList().ForEach(_ =>
                {
                    orderedPizzas.Add(pizzaModel);
                });

            }
            var orderId = PizzaAppDb.Orders.LastOrDefault()?.Id ?? 0;

            var order = new Order(++orderId, PizzaAppDb.Jovan, orderedPizzas);
            PizzaAppDb.Orders.Add(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order is null)
            {
                return new EmptyResult();
            }

            var vmodel = order.ToEditViewModel();
            return View(vmodel);
        }

        [HttpPost]
        public IActionResult Edit(int id, OrderEditViewModel model)
        {
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order is null)
            {
                return new EmptyResult();
            }
            order.Pizzas.Clear();

            var selectedPizzas = model.Pizzas.Where(x => x.IsSelected);

            var orderedPizzas = new List<Pizza>();
            foreach (var pizza in selectedPizzas)
            {
                var pizzaModel = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == pizza.PizzaId);
                if (pizzaModel == null)
                    throw new Exception("Pizza doesn't exist");


                Enumerable.Range(0, pizza.NumberOfPizzas).ToList().ForEach(_ =>
                {
                    orderedPizzas.Add(pizzaModel);
                });

            }

            order.Pizzas = orderedPizzas;

            return RedirectToAction("Index");
        }
    }
}
