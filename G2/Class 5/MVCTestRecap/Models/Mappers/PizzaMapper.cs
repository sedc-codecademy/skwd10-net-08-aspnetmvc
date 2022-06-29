using Models.Domain;
using Models.ViewModels;

namespace Models.Mappers
{
    public static class PizzaMapper
    {
        public static PizzaListViewModel ToPizzaListViewModel(this Pizza pizza)
        {
            return new PizzaListViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name
            };
        }

        public static PizzaDetailsViewModel ToPizzaDetailsViewModel(this Pizza pizza)
        {
            return new PizzaDetailsViewModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                IsOnPromotion = pizza.IsOnPromotion,
                Price = pizza.Price
            };
        }
    }
}
