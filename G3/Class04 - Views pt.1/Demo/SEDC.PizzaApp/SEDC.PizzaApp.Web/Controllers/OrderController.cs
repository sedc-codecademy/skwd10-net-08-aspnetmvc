using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Web.Helpers;
using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;
            List<OrderListViewModel> orderListViewModel = ordersFromDb
                                                .Select(x => x.MapToOrderListViewModel())
                                                .ToList();

            ViewData["Message"] = $"We have total orders of {orderListViewModel.Count}";
            ViewData["Title"] = "Orders list";
            ViewData["FirstUser"] = $"Our very first user in the system is {StaticDb.Users.FirstOrDefault()?.FirstName}";


            return View(orderListViewModel);
        }
    }
}
