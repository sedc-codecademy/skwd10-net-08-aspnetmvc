using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;

namespace PizzAppOnion.Storage.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        public IReadOnlyList<Pizza> GetAllPizzas()
        {
            return PizzaDatabase.PIZZAS;
        }

        public Pizza GetPizza(int id)
        {
            return PizzaDatabase.PIZZAS.SingleOrDefault(x => x.Id == id);
        }
    }
}
