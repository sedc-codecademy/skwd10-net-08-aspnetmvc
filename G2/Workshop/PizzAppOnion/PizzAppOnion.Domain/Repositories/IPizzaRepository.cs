using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Domain.Repositories
{
    public interface IPizzaRepository
    {
        Task<IReadOnlyList<Pizza>> GetAllPizzasAsync();

        Pizza GetPizza(int id);

        Task<IReadOnlyList<Pizza>> GetPizzasAsync(int[] pizzaIds);
        void Insert(Pizza newPizza);
        void Delete(int id);
        void Update(Pizza existingPizza);
    }
}
