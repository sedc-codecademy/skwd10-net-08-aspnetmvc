using Microsoft.AspNetCore.Mvc;
using PizzApp.Database;
using PizzApp.Models.Entities;
using System.Diagnostics;
using WebApplication1.Models;

namespace PizzApp.Controllers
{
    //  [Route("pizza")]
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> pizzas = PizzaDatabase.PIZZAS;
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            Pizza pizza = PizzaDatabase.PIZZAS.FirstOrDefault(x => x.Id == id);

            if (pizza is null)
            {
                return RedirectToAction("Error");
            }

            return View(pizza);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //    [Route("home")]
        //    [HttpGet]
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }

        //    [Route("create")]
        //    [HttpPost]
        //    public IActionResult CreatePizza()
        //    {
        //        return Ok("Success");
        //    }

        //    [Route("")]
        //    [HttpGet]
        //    public IActionResult GetPizzaById([FromQuery] int id, [FromQuery] string name)
        //    {
        //        return Ok($"{id} - {name}");
        //    }


        //    [Route("name/{pizzaName}")]
        //    [HttpGet]
        //    public IActionResult GetPizzaByName(string pizzaName)
        //    {
        //        return Ok(pizzaName);
        //    }
    }
}
