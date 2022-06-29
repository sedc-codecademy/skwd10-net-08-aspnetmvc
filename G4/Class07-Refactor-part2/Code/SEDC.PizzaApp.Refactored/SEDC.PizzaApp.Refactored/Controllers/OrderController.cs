using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Implementations;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserService _userService;

        //The constructor is called per each request
        public OrderController()
        {
            _orderService = new OrderService();
            _userService = new UserService();
        }
        public IActionResult Index()
        {
            //view models
            List<OrderDetailsViewModel> viewModels = _orderService.GetAllOrders();
            return View(viewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch(Exception e)
            {
                return View("GeneralError");
            }
        }

        //GET call
        //Return view with form
        public IActionResult CreateOrder()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            ViewBag.Users = _userService.GetAllUsersForDropdown();

            return View(orderViewModel);
        }

        public IActionResult CreateOrderPost(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("GeneralError");
            }
        }
    }
}
