using PizzaApp1.Models.Domain;
using PizzaApp1.Models.Enums;

namespace PizzaApp1
{
    public static class PizzaDb
    {
        public static User Jovan = new User();
        public static IList<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(1, "Kapricioza", 200, PizzaSize.Small),
            new Pizza(2, "KvatroFormadzi", 400, PizzaSize.Medium),
        };

        public static int SavePizza(Pizza pizza)
        {
            var pizzaId = Pizzas.OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0;
            pizza.Id = ++pizzaId;
            Pizzas.Add(pizza);
            return pizza.Id;
        }

        public static void UpdatePizza(Pizza model)
        {
            var pizzaIndex = 0;
            foreach(var pizza in Pizzas)
            {
                if(pizza.Id == model.Id)
                {
                    break;
                }
                pizzaIndex++;
            }
            // 0 -> pizza
            // 1 -> pizza
            if (Pizzas[pizzaIndex] is not null)
            {
                Pizzas[pizzaIndex] = model;
            }
        }

        public static void DeletePizza(int id)
        {
            //var pizzaIndex = 0;
            //foreach (var pizza in Pizzas)
            //{
            //    if (pizza.Id == id)
            //    {
            //        break;
            //    }
            //    pizzaIndex++;
            //}
            //Pizzas.RemoveAt(pizzaIndex);

            var model = Pizzas.FirstOrDefault(x => x.Id == id);
            if(model is not null)
            {
                DeletePizza(model);
            }
        }

        public static void DeletePizza(Pizza model)
        {
            Pizzas.Remove(model);
        }
    }
}
