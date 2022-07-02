using PizzaApp.Application.ViewModel.Pizza;
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Mapper
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToPizzaViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Size = pizza.Size
            };
        }

        public static Pizza ToPizza(this CreatePizzaViewModel create)
        {
            return new Pizza(create.Name, create.Price, create.Size);
        }

        public static Pizza Edit(this Pizza pizza, PizzaViewModel model)
        {
            pizza.Name = model.Name;
            pizza.Size = model.Size;
            pizza.Price = model.Price;
            return pizza;
        }
    }
}
