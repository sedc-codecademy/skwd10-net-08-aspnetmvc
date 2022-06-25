using PizzaApp1.Models.Domain;
using PizzaApp1.Models.ViewModel;

namespace PizzaApp1.Models.Mapper
{
    public static class OrderMapper
    {
        public static OrderEditViewModel ToEditViewModel(this Order order)
        {
            return new OrderEditViewModel
            {
                Id = order.Id,
                Pizzas = order.Pizzas
                .GroupBy(x => x.Id)
                .Select(x => new SelectPizzaEditItem
                {
                    PizzaId = x.Key,
                    NumberOfPizzas = x.Count(),
                    IsSelected = true,
                }).ToList()
            };
        }
    }
}
