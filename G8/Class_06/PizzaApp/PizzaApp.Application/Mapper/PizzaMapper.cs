using PizzaApp.Application.ViewModel.Pizza;
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Mapper
{
    public static class PizzaMapper
    {
        public static Pizza CreatePizza(PizzaPostViewModel model)
        {
            return new Pizza(0, model.Name, model.Price, model.Size);
        }

        public static PizzaViewModel ToPizzaViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Size = pizza.Size
            };
        }
    }
}
