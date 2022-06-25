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

        public static List<Order> ORDERS = new List<Order>()
        {
            new Order() { Id = 1, CreatedAt = new DateTime(2022, 02, 02), Pizzas = new List<Pizza>()
                {
                PIZZAS.First(), PIZZAS.Last()
                }
            },
            new Order() { Id = 2, CreatedAt = new DateTime(2019, 05, 02), Pizzas = new List<Pizza>()
                {
                PIZZAS.First(), PIZZAS.ElementAt(1)
                }
            }
        };

        public static int GetNextOrderId()
        {
            return (ORDERS.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
        }
    }
}
