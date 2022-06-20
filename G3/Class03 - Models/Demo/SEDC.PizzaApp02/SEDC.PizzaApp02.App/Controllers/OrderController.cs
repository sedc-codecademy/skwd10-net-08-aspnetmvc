using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp02.App;
using SEDC.PizzaApp03.App.Models.Domain;
using SEDC.PizzaApp03.App.Models.ViewModels;

namespace SEDC.PizzaApp03.App.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            //1. Get all orders from db
            List<Order> ordersFromDb = StaticDb.Orders;
            List<OrderListViewModel> model = new List<OrderListViewModel>();

            //2. For each order get only pizza name and user full name 
            //3. Use that info to create OrderListViewModel
            foreach (var order in ordersFromDb)
            {
                OrderListViewModel orderModel = new OrderListViewModel
                {
                    PizzaName = order.Pizza.Name,
                    UserFullName = $"{order.User.FirstName} {order.User.LastName}"
                };
                model.Add(orderModel);
            }
            return View(model);
        }
    }
}
