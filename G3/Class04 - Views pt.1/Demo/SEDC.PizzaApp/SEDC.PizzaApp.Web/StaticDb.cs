using SEDC.PizzaApp.Web.Models.Domain;
using SEDC.PizzaApp.Web.Models.Enums;

namespace SEDC.PizzaApp.Web
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new()
        {
            new Pizza
            {
                Id = 1,
                Name = "Capri",
                Price = 220,
                IsOnPromotion = false
            },
            new Pizza
            {
                Id = 2,
                Name = "Pepperoni",
                Price = 320,
                IsOnPromotion = false
            },
            new Pizza
            {
                Id = 3,
                Name = "Vege",
                Price = 100,
                IsOnPromotion = true
            }
        };


        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                Address = "Bob street 22"
            },
            new User
            {
                Id = 2,
                FirstName = "Jill",
                LastName = "Wayne",
                Address = "Jill street 23"
            },
        };


        public static List<Order> Orders = new List<Order>
        {
            new Order
            {
                Id = 1,
                User = Users.First(),
                Pizza = Pizzas.Last(),
                PaymentMethod = PaymentMethod.Card
            },
            new Order
            {
                Id = 2,
                User = Users.Last(),
                Pizza = Pizzas.First(),
                PaymentMethod = PaymentMethod.Cash
            }
        };
    }
}
