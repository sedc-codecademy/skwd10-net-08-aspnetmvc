﻿using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Mappers
{
    public class OrderMapper
    {
        public OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            double price = 0;
            foreach(var pizzaOrder in order.PizzaOrders)
            {
                price += pizzaOrder.Price;
            }

            return new OrderDetailsViewModel
            {
                Id = order.Id,
                Delivered = order.Delivered,
                PaymentMethod = order.PaymentMethod,
                UserFullName = $"{order.User.FirstName} {order.User.LastName}",
                //Price = price,
                Price = order.PizzaOrders.Sum(x => x.Price),
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }
    }
}
