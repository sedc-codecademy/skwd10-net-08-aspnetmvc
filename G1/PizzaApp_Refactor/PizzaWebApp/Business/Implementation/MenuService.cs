using Business.Abstraction;
using DataAccess.Helpers;
using DataAccess.Storage;
using DomainModels;
using Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace Business.Implementation
{
    public class MenuService : IMenuService
    {
        public List<MenuItemViewModel> GetAll()
        {
            var menu = PizzaDb.MenuItems.Select(x => x.ToViewModel()).OrderBy(x => x.Pizza.Name).ThenBy(x => x.Size.Description).ToList();
            return menu;
        }

        public MenuItemCreateEditViewModel GetCreateEditViewModelById(int id)
        {
            var item = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new Exception($"Menu item with that id does not exist");
            }

            var menuItem = new MenuItemCreateEditViewModel
            {
                Id = item.Id,
                Price = item.Price,
                SelectedPizzaId = item.Pizza.Id,
                SelectedSizeId = item.Size.Id
            };

            return menuItem;
        }

        public void Save(MenuItemCreateEditViewModel model)
        {
            if (model.SelectedSizeId == 0 || model.SelectedPizzaId == 0 || model.Price == 0)
            {
                throw new Exception($"All properties are required.");
            }

            var selectedSize = PizzaDb.Sizes.FirstOrDefault(x => x.Id == model.SelectedSizeId);

            if (selectedSize == null)
            {
                throw new Exception($"Selected size does not exist.");
            }

            var selectedPizza = PizzaDb.Pizzas.FirstOrDefault(x => x.Id == model.SelectedPizzaId);

            if (selectedPizza == null)
            {
                throw new Exception($"Selected pizza does not exist.");
            }

            if (model.Price <= 0)
            {
                throw new Exception("Price should be larger than 0.");
            }

            if (PizzaDb.MenuItems.Any(x => x.Id != model.Id && x.Pizza.Id == model.SelectedPizzaId && x.Size.Id == model.SelectedSizeId))
            {
                throw new Exception($"This menu item already exist.");
            }

            if (model.Id == 0)
            {
                var menuItem = new MenuItem(CommonHelper.GetRandomId(), selectedPizza, selectedSize, model.Price);

                PizzaDb.MenuItems.Add(menuItem);

                return;
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
        }

        public void Delete(int id)
        {
            var existingMenuItem = PizzaDb.MenuItems.FirstOrDefault(x => x.Id == id);

            if (existingMenuItem == null)
            {
                throw new Exception($"Menu item does not exist.");
            }

            PizzaDb.MenuItems.Remove(existingMenuItem);
        }

        public List<SelectListItem> GetMenuItemsSelectList()
        {
            return PizzaDb.MenuItems.Select(x => new SelectListItem(x.ToString(), x.Id.ToString())).ToList();
        }
    }
}
