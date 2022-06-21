using Models.Domain;

namespace Database
{
    public static class PizzaDb
    {
        public static List<Pizza> PIZZAS = new List<Pizza>()
        {

            new Pizza() { Id = 1, Name = "Margherita", Price = 10m, IsOnPromotion = false },
            new Pizza() { Id = 2, Name = "Capriciosa", Price = 12m, IsOnPromotion = false },
            new Pizza() { Id = 3, Name = "Vesuvio", Price = 7.99m, IsOnPromotion = true },
            new Pizza() { Id = 4, Name = "Oliva", Price = 15m, IsOnPromotion = true }
        };
    }
}
