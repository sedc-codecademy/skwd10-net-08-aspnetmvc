using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }
            Order orderFromDb = StaticDb.Orders.SingleOrDefault(x => x.Id == id);

            if(orderFromDb == null)
            {
                return NotFound();
            }

            OrderDetailsViewModel orderDetailsViewModel = orderFromDb.MapToOrderDetailsViewModel();

            return View(orderDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Users = StaticDb.Users
                .Select(x => x.MapToUserSelectViewModel())
                .ToList();

            // Another way - Prepare the select list into the controller
            var users = new SelectList(StaticDb.Users
                .Select(x => x.MapToUserSelectViewModel())
                .ToList(), "Id", "FullName");

            OrderViewModel order = new OrderViewModel();
            return View(order);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                orderViewModel.Id = StaticDb.Orders.Count() + 1;
                

                Pizza pizzaFromDb = StaticDb
                                    .Pizzas
                                    .FirstOrDefault(x => x.Name.ToLower() == orderViewModel.PizzaName.ToLower());

                if(pizzaFromDb == null)
                {
                    return View("ResourceNotFound");
                }
                StaticDb.Orders.Add(orderViewModel.MapToOrder());
                return RedirectToAction("Index");
            }

            return View(orderViewModel);
        }

        // Create EDIT action for home
        // Add EditViewModel
        // Add view for editing orders
        // Dont't forget to populate the users list so that it will be displayed for editing


        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order orderFromDb = StaticDb.Orders.SingleOrDefault(x => x.Id == id);
            if(orderFromDb == null)
            {
                return View("ResourceNotFound");
            }

            OrderDetailsViewModel orderDetailsViewModel = orderFromDb.MapToOrderDetailsViewModel();

            return View(orderDetailsViewModel);
        }


        public IActionResult ConfirmDelete(int? id)
        {
            Order orderFromDb = StaticDb.Orders.SingleOrDefault(x => x.Id == id);
            if(orderFromDb == null)
            {
                return View("ResourceNotFound");
            }
            StaticDb.Orders.Remove(orderFromDb);
            return RedirectToAction("Index");
        }

        public JsonResult DeleteOrder(int id)
        {
            Order orderFromDb = StaticDb.Orders.SingleOrDefault(x => x.Id == id);
            if (orderFromDb == null)
            {
                var res = new { IsDeleted = false, Message = "Delete failed" };
                return new JsonResult(res);
            }
            StaticDb.Orders.Remove(orderFromDb);
            var result = new { IsDeleted = true, Message = "Successfully deleted order!" };
            return new JsonResult(result);
        }
    }
}
