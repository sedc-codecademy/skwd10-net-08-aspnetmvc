using Microsoft.EntityFrameworkCore;
using SEDC.PizzaApp.Domain.Enums;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.DataAccess.Data
{
    public static class DataSeed
    {
        public static void InsertDataInDb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasData(new Pizza
                {
                    Id = 1,
                    Name = "Cappricioza",
                    IsOnPromotion = true
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    IsOnPromotion = false
                },
                new Pizza
                {
                    Id = 3,
                    Name = "Margarita",
                    IsOnPromotion = false
                }
                );

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Address = "Bob Street 22"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Wayne",
                    Address = "Wayne Street 33"
                });

            modelBuilder.Entity<Order>()
               .HasData(new Order
               {
                   Id = 1,
                   PaymentMethod = PaymentMethod.Card,
                   IsDelivered = true,
                   Location = "Store1",
                   UserId = 1
               },
               new Order
               {
                   Id = 2,
                   PaymentMethod = PaymentMethod.Cash,
                   IsDelivered = false,
                   Location = "Store2",
                   UserId = 2
               });

            modelBuilder.Entity<PizzaOrder>()
                .HasData(new PizzaOrder
                {
                    Id = 1,
                    OrderId = 1,
                    PizzaId = 1,
                },
                new PizzaOrder
                {
                    Id = 2,
                    OrderId = 1,
                    PizzaId = 2,
                },
                 new PizzaOrder
                 {
                     Id = 3,
                     OrderId = 2,
                     PizzaId = 2,
                 });
        }
    }
}
