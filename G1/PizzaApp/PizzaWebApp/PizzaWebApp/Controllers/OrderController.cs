using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.DomainModels;
using PizzaWebApp.Helpers;
using PizzaWebApp.Mappers;
using PizzaWebApp.Models;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            var orders = PizzaDb.Orders.Select(x => x.ToViewModel()).ToList();
            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            return View(new OrderViewModel());
        }

        [HttpPost]
        public IActionResult Save(OrderViewModel model)
        {
            var order = new Order(CommonHelper.GetRandomId(), model.Address, model.PhoneNumber, model.Note, new List<OrderItem>());

            PizzaDb.Orders.Add(order);

            return RedirectToAction("Details", new { id = order.Id });
        }

        public IActionResult Details(int id)
        {
            var order = PizzaDb.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            return View(order.ToViewModel());
        }

        public IActionResult Delete(int id)
        {
            var existingOrder = PizzaDb.Orders.FirstOrDefault(x => x.Id == id);

            if (existingOrder == null)
            {
                throw new Exception($"Order with id {id} does not exist");
            }

            PizzaDb.Orders.Remove(existingOrder);

            return RedirectToAction("Index");
        }
    }
}
