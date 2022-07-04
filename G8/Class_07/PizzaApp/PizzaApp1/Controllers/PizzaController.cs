//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using PizzaApp1.Models.Domain;
//using PizzaApp1.Models.Enums;
//using PizzaApp1.Models.Mapper;
//using PizzaApp1.Models.ViewModel;

//namespace PizzaApp1.Controllers
//{
//    public class PizzaController : Controller
//    {
//        // /pizza
//        // /pizza/index ? classname = classa & classname2=classa2
//        //public IActionResult Index(string? id, string className)
//        //{
//        //    var pizzas = PizzaDb.Pizzas.ToList();
//        //    var model = new PizzaIndexViewModel
//        //    {
//        //        Pizzas = pizzas,
//        //        Test = new List<int>
//        //        {
//        //            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
//        //        },
//        //        PriceClassName = className
//        //    };
//        //    return View(model);
//        //}
//        public IActionResult Index()
//        {
//            var pizzas = PizzaAppDb.Pizzas.ToList();
//            var model = new PizzaIndexViewModel
//            {
//                Pizzas = pizzas
//            };

//            // / ~/Home/index.cshtml
//            // ../home/index.cshtml
//            return View(model);
//        }

//        public IActionResult Details(int id)
//        {
//            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

//            if (pizza is null)
//            {
//                return NotFound();
//            }

//            return View(pizza);
//        }
//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

//            if (pizza is null)
//            {
//                return new EmptyResult();
//            }

//            return View(pizza);
//        }
//        [HttpPost]
//        public IActionResult Edit(int id, Pizza model)
//        {
//            if (model is null)
//            {
//                return BadRequest();
//            }
//            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);
//            if (pizza is null)
//            {
//                return new EmptyResult();
//            }
//            model.Id = id;
//            PizzaAppDb.UpdatePizza(model);

//            return RedirectToAction("Index");
//        }

//        // get - za zimanja informacii od serverot 
//        // post - za postiranje/ kreiranje nesto na servort
//        // put za edit
//        // delete da izbriseme neso od serverot
//        // get
//        [HttpGet]
//        //[Route("pizza/create/{id:string}/{title:string}")]
//        //// pizza/create/1/Kapri
//        //// pizza/create/1/Peperoni

//        public IActionResult Create()
//        {
//            var model = new CreatePizzaViewModel()
//            {
//                Sizes = new List<PizzaSize>
//                {
//                    PizzaSize.Small,
//                    PizzaSize.Medium,
//                    PizzaSize.Large
//                }
//            };
//            return View(model);
//        }

//        // order/{orderId:int}/pizza/{pizzaId}/toppings/{toppingId:id}
//        //order/1/pizza/1/toppings/1

//        [HttpPost]
//        public IActionResult Create(PizzaPostViewModel model)
//        {
//            var pizza = PizzaMapper.CreatePizza(model);
//            var pizzaId = PizzaAppDb.SavePizza(pizza);
//            return RedirectToAction("Index");
//        }

//        [HttpGet("Pizza/Delete/{id}")]
//        public IActionResult GetDeletePage(int id)
//        {
//            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

//            if (pizza is null)
//            {
//                return new EmptyResult();
//            }

//            return View(pizza);
//        }

//        [HttpPost]
//        public IActionResult Delete(int id)
//        {
//            var pizza = PizzaAppDb.Pizzas.FirstOrDefault(x => x.Id == id);

//            if (pizza is null)
//            {
//                return new EmptyResult();
//            }

//            PizzaAppDb.DeletePizza(pizza);
//            return RedirectToAction("Index");
//        }
//    }
//}
