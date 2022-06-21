using AutoMapper;
using Database;
using Microsoft.AspNetCore.Mvc;
using Models.Mappers;
using Models.ViewModels;

namespace Controllers
{
    public class PizzaController : Controller
    {
        private readonly IMapper _mapper;

        public PizzaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<PizzaListViewModel> pizzaListViewModel = PizzaDb.PIZZAS.Select(x => _mapper.Map<PizzaListViewModel>(x)).ToList();
            ViewData["PizzaCount"] = pizzaListViewModel.Count;

            ViewBag.AllPizzas = pizzaListViewModel;
            return View(pizzaListViewModel);
        }

        [HttpGet]
        [Route("pizza-details")]
        public IActionResult Details([FromQuery] int id)
        {   
           var pizza = PizzaDb.PIZZAS.FirstOrDefault(x => x.Id == id);
           PizzaDetailsViewModel pizzaDetailsViewModel = _mapper.Map<PizzaDetailsViewModel>(pizza);
           ViewData["Message"] = "The pizza is great!";
           return View(pizzaDetailsViewModel);
        }
    }
}
