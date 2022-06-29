using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaWebApp.DomainModels;
using PizzaWebApp.Helpers;
using PizzaWebApp.Mappers;
using PizzaWebApp.Models;
using PizzaWebApp.Storage;

namespace PizzaWebApp.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            var menu = PizzaDb.MenuItems.Select(x => x.ToViewModel()).OrderBy(x => x.Pizza.Name).ThenBy(x => x.Size.Description).ToList();

            return View(menu);
        }

        public IActionResult CreateEditMenuItem(int? id)
        {
            var menuItem = new MenuItemCreateEditViewModel();

            if(id.HasValue)
            {
                var item = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == id);

                if(item == null)
                {
                    throw new Exception($"Menu item with that id does not exist");
                }

                menuItem = new MenuItemCreateEditViewModel
                {
                    Id = item.Id,
                    Price = item.Price,
                    SelectedPizzaId = item.Pizza.Id,
                    SelectedSizeId = item.Size.Id
                };
            }

            ViewBag.Pizzas = PizzaDb.Pizzas.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
            ViewBag.Sizes = PizzaDb.Sizes.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            return View(menuItem);
        }

        public IActionResult Save(MenuItemCreateEditViewModel model)
        {
            if(model.SelectedSizeId == 0 || model.SelectedPizzaId == 0 || model.Price == 0)
            {
                throw new Exception($"All properties are required.");
            }

            var selectedSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == model.SelectedSizeId);

            if(selectedSize == null)
            {
                throw new Exception($"Selected size does not exist.");
            }

            var selectedPizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == model.SelectedPizzaId);

            if (selectedPizza == null)
            {
                throw new Exception($"Selected pizza does not exist.");
            }

            if(model.Price <= 0)
            {
                throw new Exception("Price should be larger than 0.");
            }

            if(PizzaDb.MenuItems.Any(x => x.Id != model.Id && x.Pizza.Id == model.SelectedPizzaId && x.Size.Id == model.SelectedSizeId))
            {
                throw new Exception($"This menu item already exist.");
            }

            if(model.Id == 0)
            {
                var menuItem = new MenuItem(CommonHelper.GetRandomId(), selectedPizza, selectedSize, model.Price);

                PizzaDb.MenuItems.Add(menuItem);

                return RedirectToAction("Index");
            }

            var existingMenuItem = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == model.Id);

            if (existingMenuItem == null)
            {
                throw new Exception($"Menu item does not exist.");
            }

            PizzaDb.MenuItems.Remove(existingMenuItem);

            existingMenuItem.Pizza = selectedPizza;
            existingMenuItem.Size = selectedSize;
            existingMenuItem.Price = model.Price;

            PizzaDb.MenuItems.Add(existingMenuItem);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var existingMenuItem = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == id);

            if (existingMenuItem == null)
            {
                throw new Exception($"Menu item does not exist.");
            }

            PizzaDb.MenuItems.Remove(existingMenuItem); 

            return RedirectToAction("Index");
        }
    }
}
