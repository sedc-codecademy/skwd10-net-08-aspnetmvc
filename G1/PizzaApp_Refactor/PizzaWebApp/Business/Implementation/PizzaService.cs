using Business.Abstraction;
using DataAccess.Helpers;
using DataAccess.Storage;
using DomainModels;
using Mappers;
using ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Business.Implementation
{
    public class PizzaService : IPizzaService
    {
        public List<PizzaViewModel> GetAll()
        {
            var pizzas = PizzaDb.Pizzas.Select(x => x.ToViewModel()).OrderBy(x => x.Name).ToList();
            return pizzas;
        }

        public PizzaViewModel GetById(int id)
        {
            var pizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if (pizza == null)
            {
                throw new Exception($"Pizza with Id {id} not found");
            }

            return pizza.ToViewModel();
        }

        public void Save(PizzaViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name)
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

                return;
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
        }

        public void Delete(int id)
        {
            var existingPizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);

            if (existingPizza == null)
            {
                throw new Exception($"Pizza with id {id} does not exist");
            }

            var menuItems = PizzaDb.MenuItems.Where(x => x.Pizza.Id == id).ToList();

            foreach (var menuItem in menuItems)
            {
                PizzaDb.MenuItems.Remove(menuItem);
            }

            PizzaDb.Pizzas.Remove(existingPizza);
        }

        public List<SelectListItem> GetPizzasSelectList()
        {
            return PizzaDb.Pizzas.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }
    }
}
