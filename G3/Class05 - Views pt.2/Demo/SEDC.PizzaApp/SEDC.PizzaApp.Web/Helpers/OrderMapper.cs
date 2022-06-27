using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.ViewModels;

namespace SEDC.PizzaApp.Web.Helpers
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}"
            };
        }

        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                PizzaName = order.Pizza.Name,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PaymentMethod = order.PaymentMethod,
                Price = order.Pizza.IsOnPromotion ? 200 : order.Pizza.Price,
                IsDelivered = order.IsDelivered
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Id = orderViewModel.Id,
                PaymentMethod = orderViewModel.PaymentMethod,
                User = StaticDb.Users.SingleOrDefault(x => x.Id == orderViewModel.UserId),
                IsDelivered = false,
                Pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Name == orderViewModel.PizzaName)
            };
        }
    }
}
