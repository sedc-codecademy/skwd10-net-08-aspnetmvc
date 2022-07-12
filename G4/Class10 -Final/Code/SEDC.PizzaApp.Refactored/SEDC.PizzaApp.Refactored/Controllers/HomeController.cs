using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Refactored.Models;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.Shared.CustomExceptions;
using SEDC.PizzaApp.ViewModels.HomeViewModels;
using System.Diagnostics;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class HomeController : Controller
    {
        private IPizzaService _pizzaService;

        public HomeController(IPizzaService pizzaService) //DI
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            try
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                homeViewModel.MostPopularPizza = _pizzaService.GetMostPopularPizza();
                homeViewModel.PizzaOnPromotion = _pizzaService.GetPizzaOnPromotion();

                return View(homeViewModel);
            }
            catch(NoPizzaOnPromotionException e)
            {
                return View("NoPizzaOnPromotion");
            }
            catch(Exception e)
            {
                return View("GeneralError");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}