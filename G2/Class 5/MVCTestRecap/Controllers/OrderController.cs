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
    }
}
