using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Mappers.Extensions;
using SEDC.PizzaApp.Services.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    // Connect MVC Application with Database using EntityFramework
    
    // 1. Install nuget packages for EntityFramework.Core - Check the README.md
    // 2. Implement DbContext class with all the db sets and relation configurations
    // 3. Add the dbContext in Program.cs class
    // 4. Inject the dbContext in the Repositories and use it

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModel = _orderService.GetAllOrders();
            return View(orderListViewModel);
        }

        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetUsersForDropdown();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }
    }
}
