using Microsoft.AspNetCore.Mvc;
using PizzaApp.Application.Services;
using PizzaApp.Application.ViewModel;
using PizzaApp.Application.ViewModel.Order;

namespace PizzaApp1.Controllers
{
    // order
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IPizzaService pizzaService;

        public OrderController(IOrderService orderService, IPizzaService pizzaService)
        {
            this.orderService = orderService;
            this.pizzaService = pizzaService;
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
            var pizzas = pizzaService.GetAllPizza();
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
            var model = orderService.GetOrder(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, OrderEditViewModel model)
        {
            orderService.EditOrder(id, model);
            return RedirectToAction("Index");
        }
    }
}
