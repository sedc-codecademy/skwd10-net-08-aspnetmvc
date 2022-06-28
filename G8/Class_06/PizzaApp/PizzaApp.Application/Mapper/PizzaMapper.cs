using PizzaApp.Domain.Models;
using PizzaApp.Domain.ViewModel;

namespace PizzaApp.Application.Mapper
{
    public static class PizzaMapper
    {
        public static Pizza CreatePizza(PizzaPostViewModel model)
        {
            return new Pizza(0, model.Name, model.Price, model.Size);
        }
    }
}
