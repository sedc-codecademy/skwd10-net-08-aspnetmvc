using PizzApp.Models.Entities;

namespace PizzApp.Database
{
    public static class PizzaDatabase
    {
        public static List<Pizza> PIZZAS = new List<Pizza>()
        {

            new Pizza() { Id = 1, Name = "Margherita", Price = 10m, IsOnPromotion = false },
            new Pizza() { Id = 2, Name = "Capriciosa", Price = 12m, IsOnPromotion = false },
            new Pizza() { Id = 3, Name = "Vesuvio", Price = 7.99m, IsOnPromotion = true }
        };
    }
}
