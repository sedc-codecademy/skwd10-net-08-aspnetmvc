using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Order;

namespace PizzAppOnion.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPizzaService _pizzaService;

        public OrderController(IOrderService orderService,
                               IPizzaService pizzaService)
        {
            _orderService = orderService;
            _pizzaService = pizzaService;
        }

        // GET: OrderController
        public async Task<ActionResult> Index()
        {
            IEnumerable<OrderViewModel> orderListViewModel = await _orderService.GetAllOrders();

            return View(orderListViewModel);
        }

        // GET: OrderController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            OrderViewModel order = await _orderService.GetOrder(id);
            return View(order);
        }

        // GET: OrderController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Pizzas = await _pizzaService.GetAllPizzasAsync();
            OrderViewModel orderViewModel = new();
            return View(orderViewModel);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderViewModel order)
        {
            await _orderService.CreateOrderAsync(order);

            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Pizzas = await _pizzaService.GetAllPizzasAsync();
            OrderViewModel order = await _orderService.GetOrder(id);
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderViewModel order)
        {
            _orderService.UpdateOrder(id, order);
            return RedirectToAction("Edit", id);
        }

        // GET: OrderController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            OrderViewModel order = await _orderService.GetOrder(id);
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _orderService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}
