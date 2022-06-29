using Microsoft.AspNetCore.Mvc;
using PizzaWebApp.DomainModels;
using PizzaWebApp.Helpers;
using PizzaWebApp.Mappers;
using PizzaWebApp.Models;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            var pizzas = PizzaDb.Pizzas.Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            var pizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if(pizza == null)
            {
                throw new Exception($"Pizza with Id {id} not found");
            }

            return View(pizza.ToViewModel());
        }

        public IActionResult CreateEditPizza(int? id)
        {
            var model = new PizzaViewModel();

            if (id.HasValue)
            {
                var domainModel = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id.Value);

                if(domainModel == null)
                {
                    throw new Exception($"Pizza with id {id} does not exist");
                }

                model = domainModel.ToViewModel();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Save(PizzaViewModel model)
        {
            if(string.IsNullOrEmpty(model.Name) 
                || string.IsNullOrEmpty(model.Description) 
                || string.IsNullOrEmpty(model.ImageUrl))
            {
                throw new Exception($"All properties are required.");
            }

            if (PizzaDb.Pizzas.Any(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id))
            {
                throw new Exception($"Pizza with the name {model.Name} already exists");
            }


            if (model.Id == 0)
            {
                var pizza = new Pizza(CommonHelper.GetRandomId(), model.Name, model.Description, model.ImageUrl);

                PizzaDb.Pizzas.Add(pizza);

                return RedirectToAction("Index");
            }

            var existingPizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == model.Id);

            if (existingPizza == null)
            {
                throw new Exception($"Pizza with id {model.Id} does not exist");
            }

            PizzaDb.Pizzas.Remove(existingPizza);

            existingPizza.Name = model.Name;
            existingPizza.Description = model.Description;
            existingPizza.ImageUrl = model.ImageUrl;

            PizzaDb.Pizzas.Add(existingPizza);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existingPizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if (existingPizza == null)
            {
                throw new Exception($"Pizza with id {id} does not exist");
            }

            var menuItems = PizzaDb.MenuItems.Where(x => x.Pizza.Id == id).ToList();

            foreach(var menuItem in menuItems)
            {
                PizzaDb.MenuItems.Remove(menuItem);
            }

            PizzaDb.Pizzas.Remove(existingPizza);

            return RedirectToAction("Index");
        }
    }
}
