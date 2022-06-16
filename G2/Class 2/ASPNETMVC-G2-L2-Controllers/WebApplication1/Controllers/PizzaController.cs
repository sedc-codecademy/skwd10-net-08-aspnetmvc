using Microsoft.AspNetCore.Mvc;

namespace PizzApp.Controllers
{
    [Route("pizza")]
    public class PizzaController : Controller
    {
        [Route("home")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreatePizza()
        {
            return Ok("Success");
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetPizzaById([FromQuery] int id, [FromQuery] string name)
        {
            return Ok($"{id} - {name}");
        }


        [Route("name/{pizzaName}")]
        [HttpGet]
        public IActionResult GetPizzaByName(string pizzaName)
        {
            return Ok(pizzaName);
        }
    }
}
