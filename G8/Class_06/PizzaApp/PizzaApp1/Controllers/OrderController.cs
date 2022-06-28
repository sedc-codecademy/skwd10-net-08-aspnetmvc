using Microsoft.AspNetCore.Mvc;
using PizzaApp.Application.Services;
using PizzaApp.Application.Services.Implementation;
using PizzaApp.Application.ViewModel;
using PizzaApp.StaticDb.Repository;
using PizzaApp1.Models.Db;
using PizzaApp1.Models.Domain;
using PizzaApp1.Models.Mapper;
using PizzaApp1.Models.ViewModel;

namespace PizzaApp1.Controllers
{
    // order
    public class OrderController : Controller
    {
        private IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            var orders = PizzaAppDb.Orders.ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            return View(orderService.GetOrder(id));
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
            orderService.CreateOrder(model, PizzaAppDb.Jovan);
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
            using var db = new ApplicationDbContext();
            var order = db.Orders.FirstOrDefault(x => x.Id == id);
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
