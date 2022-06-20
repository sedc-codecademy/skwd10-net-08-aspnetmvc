using Microsoft.AspNetCore.Mvc;
using PizzaApp1.Models.ViewModel;

namespace PizzaApp1.Controllers
{
    public class PizzaController : Controller
    {
        // /pizza
        // /pizza/index
        //public IActionResult Index(string? id, string className)
        //{
        //    var pizzas = PizzaDb.Pizzas.ToList();
        //    var model = new PizzaIndexViewModel
        //    {
        //        Pizzas = pizzas,
        //        Test = new List<int>
        //        {
        //            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        //        },
        //        PriceClassName = className
        //    };
        //    return View(model);
        //}

        public IActionResult Index()
        {
            var pizzas = PizzaDb.Pizzas.ToList();
            var model = new PizzaIndexViewModel
            {
                Pizzas = pizzas
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var pizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza is null)
            {
                return NotFound();
            }
   
            return View(pizza);
        }
    }
}
