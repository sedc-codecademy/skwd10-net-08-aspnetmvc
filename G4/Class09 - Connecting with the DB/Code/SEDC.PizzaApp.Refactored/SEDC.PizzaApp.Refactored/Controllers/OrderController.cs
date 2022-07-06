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
        private IPizzaService _pizzaService;

        //The constructor is called per each request
        public OrderController(IOrderService orderService, IUserService userService, IPizzaService pizzaService)
        {
            _orderService = orderService;
            _userService = userService;
            _pizzaService = pizzaService;
        }
        //Order/Index
        public IActionResult Index()
        {
            //view models
            List<OrderDetailsViewModel> viewModels = _orderService.GetAllOrders();
            return View(viewModels);
        }

        //Order/Details/1
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

        public IActionResult AddPizza(int id) //id -> orderId
        {
            ViewBag.Pizzas = _pizzaService.GetPizzasForDropdown();

            AddPizzaViewModel addPizzaViewModel = new AddPizzaViewModel();
            //we send the order id, in order not to lose it between calls (GET and POST)
            addPizzaViewModel.OrderId = id;
            return View(addPizzaViewModel);
        }

        [HttpPost]
        public IActionResult AddPizzaPost(AddPizzaViewModel addPizzaViewModel)
        {
            try
            {
                _orderService.AddPizzaToOrder(addPizzaViewModel);
                //when we redirect to Details we must send the id ( parameter in the route)
                //the route parameters are sent by an object which has properties with the names of the route parameters.
                return RedirectToAction("Details", new { id = addPizzaViewModel.OrderId }); //Order/Details/id
            }
            catch(Exception e)
            {
                return View("GeneralError");
            }
        }

        //This method returns the view where the user sees the details of the order
        //and confirms that he wants to delete the order
        public IActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception e)
            {
                return View("GeneralError");
            }
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                _orderService.DeleteOrder(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("GeneralError");
            }
        }
    }
}
