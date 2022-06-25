using Models.Domain;
using Models.ViewModels;

namespace Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                TotalPrice = order.CalculateTotalPrice()
            };
        }

        public static OrderListViewModel ToOrderDetailsViewModel(this List<Order> orders)
        {
            return new OrderListViewModel
            {
                Orders = orders.Select(x => x.ToOrderViewModel()).ToList()
            };
        }
    }
}
