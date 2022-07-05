using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;

namespace PizzAppOnion.Storage.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        public void Delete(int id)
        {
            Pizza pizza = GetPizza(id);

            if (pizza is null)
            {
                throw new Exception($"Pizza with id {id} not found");
            }

            PizzaDatabase.PIZZAS.Remove(pizza);
        }

        public IReadOnlyList<Pizza> GetAllPizzas()
        {
            return PizzaDatabase.PIZZAS;
        }

        public Pizza GetPizza(int id)
        {
            return PizzaDatabase.PIZZAS.SingleOrDefault(x => x.Id == id);
        }

        public IReadOnlyList<Pizza> GetPizzas(int[] pizzaIds)
        {
            return PizzaDatabase.PIZZAS.Where(x => pizzaIds.Contains(x.Id)).ToArray();
        }

        public void Insert(Pizza newPizza)
        {
            newPizza.Id = PizzaDatabase.GetNextPizzaId();
            PizzaDatabase.PIZZAS.Add(newPizza);
        }

        public void Update(Pizza existingPizza)
        {
            //noop
        }
    }
}
