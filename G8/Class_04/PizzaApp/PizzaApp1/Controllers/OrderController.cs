using Microsoft.AspNetCore.Mvc;
using PizzaApp1.Models.ViewModel;

namespace PizzaApp1.Controllers
{
    // order
    public class OrderController : Controller
    {
        // default view resolving
        // views/[controller]/[action].cshtml
        // views/shared/[action].cshtml

        // ~/views/.../ .cshtml

        //public IActionResult Index()
        //{
        //    return View("~/Views/Home/Index.cshtml");
        //}

        public IActionResult Index()
        {
            var orders = PizzaAppDb.Orders.ToList();
            return View(orders);
        }
        //odder/details/[1,2,3...]
        public IActionResult Details(int id)
        {
            var order = PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);
            if(order == null)
            {
                return new EmptyResult();
            }
            return View(order);
        }

        public IActionResult Create()
        {
            var pizzas = PizzaAppDb.Pizzas.ToList();
            ViewBag.Pizzas = pizzas;
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model)
        {
            var pizzas = PizzaAppDb.Pizzas.ToList();
            ViewBag.Pizzas = pizzas;
            return View();
        }
    }
}
