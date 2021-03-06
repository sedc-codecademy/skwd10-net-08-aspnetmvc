using MVCTestRecap.Models.Domain;
using MVCTestRecap.Models.ViewModels;

namespace MVCTestRecap.Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaListViewModel ToPizzaListViewModel(this Pizza pizza)
        {
            return new PizzaListViewModel()
            {
                Id = pizza.Id,
                PizzaName = pizza.Name
            };
        }

        public static PizzaDetailsViewModel ToPizzaDetailsViewModel(this Pizza pizza)
        {
            return new PizzaDetailsViewModel()
            {
                PizzaName = pizza.Name,
                IsOnPromotion = pizza.IsOnPromotion,
                Price = pizza.Price
            };
        }
    }
}
