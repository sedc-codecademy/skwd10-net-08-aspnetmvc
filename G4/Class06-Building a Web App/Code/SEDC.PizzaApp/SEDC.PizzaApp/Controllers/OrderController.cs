using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

            //dynamic a = 5;
            //a.name = 100;

            //=========map from domain models to view models===========


            //=======FIRST WAY============
            //List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => new OrderDetailsViewModel
            //{
            //    PaymentMethod = x.PaymentMethod,
            //    PizzaName = x.Pizza.Name,
            //    Price = x.Pizza.Price + 50,
            //    UserFullname = $"{x.User.FirstName} {x.User.LastName}"
            //}).ToList();

            //=======SECOND WAY============
            //List<OrderDetailsViewModel> orderViewModels = new List<OrderDetailsViewModel>();
            //foreach(Order order in ordersDb)
            //{
            //    viewModels.Add(new OrderDetailsViewModel
            //    {
            //        PaymentMethod = order.PaymentMethod,
            //        PizzaName = order.Pizza.Name,
            //        Price = order.Pizza.Price + 50,
            //        UserFullname = $"{order.User.FirstName} {order.User.LastName}"
            //    });
            //}

            //=======THIRD WAY============
            //From each object in ordersDb list we project (map) an object of type OrderDetailsViewModel
            List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x))
                .ToList();


            //return View(ordersDb);

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            ViewData["FirstUser"] = StaticDb.Orders.First().User;

            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                //return new EmptyResult();
                //return View(); //Details.cshtml -> Order folder
                return View("ResourceNotFound"); //we pass the name of the View
            }

            //======map from domain to view model===========

            //OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = orderDb.PaymentMethod,
            //    PizzaName = orderDb.Pizza.Name,
            //    Price = orderDb.Pizza.Price + 50,
            //    UserFullname = $"{orderDb.User.FirstName} {orderDb.User.LastName}"
            //};

            //From orderDb we project (map) an object of type OrderDetailsViewModel
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            ViewBag.Title = $"Details for order with id {id}";
            ViewBag.User = orderDb.User;

            //return View(orderDb);
            return View(orderDetailsViewModel);
        }

        /// <summary>
        /// this is the method that returns the View with the form in which we will fill the data for a new order
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateOrder()
        {
            //we send an empty object in order to fill in its properties through the form in the view
            //we have to send an empty model so that the form data is packed into that kind of model when it is sent via post
            OrderViewModel orderViewModel = new OrderViewModel();

            //we have to send the users, so that <option> items are generated in the select list for users
            ViewBag.Users = StaticDb.Users.Select(x => new UserDDViewModel
            {
                Id = x.Id, //value for option tag
                UserFullname = $"{x.FirstName} {x.LastName}" //text for option tag
            });

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateOrderPost(OrderViewModel orderViewModel)
        {
            //validation for user, we have to validate if the user id is of an existing user
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if(userDb == null)
            {
                return View("ResourceNotFound");
            }

            //validation for pizza, we have to validate if the pizza name is of an existing pizza
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //we add only domain model objects in the database
            Order newOrder = new Order
            {
                Id = StaticDb.OrderId + 1,
                Delivered = orderViewModel.Delivered,
                PaymentMethod = orderViewModel.PaymentMethod,
                Pizza = pizzaDb,
                User = userDb,
                PizzaId = pizzaDb.Id,
                UserId = orderViewModel.UserId
            };

            StaticDb.Orders.Add(newOrder);
            // increment the id in the database
            StaticDb.OrderId++;

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            //we have to send the users, so that <option> items are generated in the select list for users
            //the right user is bound by mapping the UserId from the view model with the value attribute from the <option> tags
            ViewBag.Users = StaticDb.Users.Select(x => new UserDDViewModel
            {
                Id = x.Id, //value for option tag
                UserFullname = $"{x.FirstName} {x.LastName}" //text for option tag
            });

            //map domain model to view model
            //we want to send view model filled with data to the view
            OrderViewModel orderViewModel = new OrderViewModel
            {
                Delivered = orderDb.Delivered,
                PaymentMethod = orderDb.PaymentMethod,
                UserId = orderDb.User.Id,
                PizzaName = orderDb.Pizza.Name,
                Id = orderDb.Id
            };
            return View(orderViewModel);
        }

        /// <summary>
        /// This is the method that receives the edited data from the form
        /// </summary>
        [HttpPost]
        public IActionResult EditOrderPost(OrderViewModel orderViewModel)
        {
            //check negative scenarios 
            //check if data is valid!!!!!!!!!

            //we have to validate if the order we want to edit exists
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderViewModel.UserId);
            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName);
            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //Take the order from db and  for each property update and update the property
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Pizza = pizzaDb;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).PizzaId = pizzaDb.Id;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).User = userDb;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).UserId = userDb.Id;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).PaymentMethod = orderViewModel.PaymentMethod;
            StaticDb.Orders.FirstOrDefault(x => x.Id == orderViewModel.Id).Delivered = orderViewModel.Delivered;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("Error");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Orders.FindIndex(x => x.Id == id);
            if(index == -1)
            {
                return View("ResourceNotFound");
            }

            StaticDb.Orders.RemoveAt(index);

            return RedirectToAction("Index");
        }
    }
}
