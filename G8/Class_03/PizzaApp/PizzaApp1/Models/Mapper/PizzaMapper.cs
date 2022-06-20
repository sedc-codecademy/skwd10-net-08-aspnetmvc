using PizzaApp1.Models.Domain;
using PizzaApp1.Models.ViewModel;

namespace PizzaApp1.Models.Mapper
{
    public static class PizzaMapper
    {
        public static Pizza CreatePizza(PizzaPostViewModel model)
        {
            return new Pizza(0, model.Name, model.Price, model.Size);
        }
    }
}
