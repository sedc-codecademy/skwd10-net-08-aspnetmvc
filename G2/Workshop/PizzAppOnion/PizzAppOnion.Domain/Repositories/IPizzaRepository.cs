using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Domain.Repositories
{
    public interface IPizzaRepository
    {
        IReadOnlyList<Pizza> GetAllPizzas();

        Pizza GetPizza(int id);

        IReadOnlyList<Pizza> GetPizzas(int[] pizzaIds);
        void Insert(Pizza newPizza);
        void Delete(int id);
        void Update(Pizza existingPizza);
    }
}
