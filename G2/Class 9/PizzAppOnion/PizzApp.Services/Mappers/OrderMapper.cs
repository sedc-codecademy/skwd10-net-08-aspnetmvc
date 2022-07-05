using PizzAppOnion.Contracts.ViewModels.Order;
using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Services.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                TotalPrice = order.CalculateTotalPrice(),
                Pizzas = order.Pizzas.Select(x => x.Id).ToArray()
            };
        }
    }
}
