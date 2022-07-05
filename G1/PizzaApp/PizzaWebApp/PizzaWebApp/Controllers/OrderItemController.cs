using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaWebApp.DomainModels;
using PizzaWebApp.Helpers;
using PizzaWebApp.Models;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult CreateOrderItem(int id)
        {
            ViewBag.MenuItems = PizzaDb.MenuItems.Select(x => new SelectListItem(x.ToString(), x.Id.ToString()));

            var orderItem = new OrderItemViewModel()
            {
                OrderId = id
            };

            return View(orderItem);
        }

        [HttpPost]
        public IActionResult Save(OrderItemViewModel model)
        {
            var order = PizzaDb.Orders.FirstOrDefault(x => x.Id == model.OrderId);

            if(order == null)
            {
                throw new Exception($"Order does not exist");
            }

            var menuItem = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == model.MenuItem.Id);

            if (menuItem == null)
            {
                throw new Exception($"Menu item does not exist");
            }

            if(model.Quantity <= 0)
            {
                throw new Exception($"Quantity must be grater than 0");
            }

            var orderItem = new OrderItem(CommonHelper.GetRandomId(), menuItem, model.Quantity);

            order.OrderItems.Add(orderItem);

            return RedirectToAction("Details", "Order", new { id = model.OrderId });
        }

        public IActionResult Delete(int id)
        {
            var existingOrder = PizzaDb.Orders.FirstOrDefault(x => x.OrderItems.Any(y => y.Id == id));

            if (existingOrder == null)
            {
                throw new Exception($"Order that contains order item with {id} does not exist");
            }

            var existingOrderItem = existingOrder.OrderItems.First(x => x.Id == id);

            existingOrder.OrderItems.Remove(existingOrderItem);

            return RedirectToAction("Details", "Order", new { id = existingOrder.Id });
        }
    }
}
