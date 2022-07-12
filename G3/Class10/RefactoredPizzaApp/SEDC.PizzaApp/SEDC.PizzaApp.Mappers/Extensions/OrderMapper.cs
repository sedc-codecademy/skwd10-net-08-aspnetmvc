using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Mappers.Extensions
{
    public static class OrderMapper
    {
        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }

        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                Delivered = order.IsDelivered,
                PaymentMethod = order.PaymentMethod,
                Location = order.Location,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }

        public static OrderViewModel MapToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                Location = order.Location,
                PaymentMethod = order.PaymentMethod,
                UserId = order.UserId
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Id = orderViewModel.Id,
                IsDelivered = orderViewModel.IsDelivered,
                PaymentMethod = orderViewModel.PaymentMethod,
                PizzaOrders = new List<PizzaOrder>(),
                UserId = orderViewModel.UserId,
                Location = orderViewModel.Location
            };
        }
    }
}
