using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Mappers.Extensions;
using SEDC.PizzaApp.Services.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;

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
        private readonly IPizzaService _pizzaService;

        public OrderController(IOrderService orderService, IUserService userService, IPizzaService pizzaService)
        {
            _orderService = orderService;
            _userService = userService;
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            List<OrderListViewModel> orderListViewModel = _orderService.GetAllOrders();
            return View(orderListViewModel);
        }

        public IActionResult Details(int? id)
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
                // We can add loggs here
                return View("ExceptionPage");

            }
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

        public IActionResult AddPizza(int id)
        {
            PizzaOrderViewModel pizzaOrderViewModel = new PizzaOrderViewModel();
            pizzaOrderViewModel.OrderId = id;
            ViewBag.Pizzas = _pizzaService.GetPizzasForDropdown();
            return View(pizzaOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddPizza(PizzaOrderViewModel pizzaOrderViewModel)
        {
            try
            {
                _orderService.AddPizzaToOrder(pizzaOrderViewModel);
                return RedirectToAction("Details", new { id = pizzaOrderViewModel.OrderId });
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderViewModel model = _orderService.GetOrderForEditing(id.Value);
                ViewBag.Users = _userService.GetUsersForDropdown();
                return View(model);
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }

        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.EditOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        public IActionResult Delete(int? id)
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
                // We can add loggs here
                return View("ExceptionPage");
            }
        }

        [HttpPost]
        public IActionResult Delete(OrderDetailsViewModel orderDetailsViewModel)
        {
            try
            {
                _orderService.DeleteOrder(orderDetailsViewModel.Id);
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
