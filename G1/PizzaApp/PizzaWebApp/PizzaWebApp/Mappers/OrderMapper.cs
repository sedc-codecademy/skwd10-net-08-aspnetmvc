using PizzaWebApp.DomainModels;
using PizzaWebApp.Models;

namespace PizzaWebApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                Address = order.Address,
                Items = order.OrderItems.Select(x => x.ToViewModel()).ToList(),
                Note = order.Note,
                PhoneNumber = order.PhoneNumber,
                TotalPrice = order.TotalPrice
            };
        }
    }
}
