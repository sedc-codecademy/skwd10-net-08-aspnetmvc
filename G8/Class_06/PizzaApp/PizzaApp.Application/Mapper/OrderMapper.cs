
using PizzaApp.Application.ViewModel;
using PizzaApp.Application.ViewModel.Order;
using PizzaApp.Application.ViewModel.Pizza;
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Mapper
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
                .Select(x => new SelectPizzaItem
                {
                    PizzaId = x.Key,
                    NumberOfPizzas = x.Count(),
                    IsSelected = true,
                }).ToList()
            };
        }

        public static OrderViewModel ToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Pizzas = order.Pizzas
                .GroupBy(x => x.Id)
                .Select(x => new SelectPizzaItem
                {
                    PizzaId = x.Key,
                    NumberOfPizzas = x.Count(),
                    IsSelected = true,
                }).ToList()
            };
        }
    }
}
