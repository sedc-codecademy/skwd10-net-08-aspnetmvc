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

            List<Order> Orders = PizzaDb.ORDERS;
            OrderListViewModel orderListViewModel = Orders.ToOrderDetailsViewModel();

            return View(orderListViewModel);
        }
    }
}
