using SEDC.PizzaApp02.App.Models.Domain;

namespace SEDC.PizzaApp02.App
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
    }
}
