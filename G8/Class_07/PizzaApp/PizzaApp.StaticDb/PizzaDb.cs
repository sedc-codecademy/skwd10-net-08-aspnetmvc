using PizzaApp.Domain.Enums;
using PizzaApp.Domain.Models;

namespace PizzaApp.StaticDb
{
    public static class PizzaAppDb
    {
        #region pizza
        public static User Jovan = new User("Jovan", "Gjorgjiev", 100, "000 000 000", "jokica@hotmail.com");

        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(1, "Kapricioza", 200, PizzaSize.Small),
            new Pizza(2, "KvatroFormadzi", 400, PizzaSize.Medium),
        };

        public static IList<Pizza> ProccessingPizzas = new List<Pizza>
        {

        };

        public static int SavePizza(Pizza pizza)
        {
            var pizzaId = Pizzas.OrderBy(x => x.Id).LastOrDefault()?.Id ?? 0;
            pizza.Id = ++pizzaId;
            ProccessingPizzas.Add(pizza);
            return pizza.Id;
        }

        public static void Commit()
        {
            Pizzas.AddRange(ProccessingPizzas);
            ProccessingPizzas.Clear();
        }

        public static void UpdatePizza(Pizza model)
        {
            var pizzaIndex = 0;
            foreach (var pizza in Pizzas)
            {
                if (pizza.Id == model.Id)
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
            if (model is not null)
            {
                DeletePizza(model);
            }
        }

        public static void DeletePizza(Pizza model)
        {
            Pizzas.Remove(model);
        }
        #endregion


        #region order

        public static IList<Order> Orders { get; set; } = new List<Order>
        {

        };

        #endregion

        #region user
        public static IList<User> Users = new List<User>();
        #endregion
    }
}
