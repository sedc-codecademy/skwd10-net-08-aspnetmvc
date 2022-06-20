using PizzaApp1.Models.Domain;

namespace PizzaApp1
{
    public static class PizzaDb
    {
        public static User Jovan = new User();
        public static IEnumerable<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(1, "Kapricioza", 200, PizzaSize.Small, Jovan),
            new Pizza(2, "KvatroFormadzi", 400, PizzaSize.Medium, Jovan),
        };
    }
}
