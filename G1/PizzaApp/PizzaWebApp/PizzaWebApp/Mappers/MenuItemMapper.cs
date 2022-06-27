using PizzaWebApp.DomainModels;
using PizzaWebApp.Models;

namespace PizzaWebApp.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItemViewModel ToViewModel(this MenuItem menuItem)
        {
            return new MenuItemViewModel
            {
                Id = menuItem.Id,
                Price = menuItem.Price,
                Pizza = menuItem.Pizza.ToViewModel(),
                Size = menuItem.Size.ToViewModel()
            };
        }
    }
}
