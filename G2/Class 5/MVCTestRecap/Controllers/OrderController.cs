using Database;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.Mappers;
using Models.ViewModels;

namespace Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<OrderViewModel> orderListViewModel = PizzaDb.ORDERS.Select(x => x.ToOrderViewModel());

            return View(orderListViewModel);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderViewModel order)
        {
            int id = PizzaDb.GetNextOrderId();

            Order newOrder = new Order()
            {
                Id = id,
                CreatedAt = order.CreatedAt,
                Pizzas = new List<Pizza>()
            };

            PizzaDb.ORDERS.Add(newOrder);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Order order = PizzaDb.ORDERS.SingleOrDefault(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order.ToOrderViewModel());
        }

        [HttpPost]
        public IActionResult Edit(int id, OrderViewModel order)
        {
            Order orderToUpdate = PizzaDb.ORDERS.SingleOrDefault(x => x.Id == id);

            if (orderToUpdate is null)
            {
                return NotFound();
            }

            orderToUpdate.CreatedAt = order.CreatedAt;

            return View(orderToUpdate.ToOrderViewModel());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order order = PizzaDb.ORDERS.SingleOrDefault(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order.ToOrderViewModel());
        }

        [HttpPost]
        public IActionResult Delete(int id, OrderViewModel order) 
        {
            Order orderToDelete = PizzaDb.ORDERS.SingleOrDefault(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            PizzaDb.ORDERS.Remove(orderToDelete);

            return RedirectToAction("Index");
        }
    }
}
