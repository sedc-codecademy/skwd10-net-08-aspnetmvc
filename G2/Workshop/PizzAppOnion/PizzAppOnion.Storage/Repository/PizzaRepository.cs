using Microsoft.EntityFrameworkCore;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;
using PizzAppOnion.Storage.Database.Context;

namespace PizzAppOnion.Storage.Repository.Repository
{
    public class PizzaRepository : RepositoryBase<Pizza>, IPizzaRepository
    {
        public PizzaRepository(IPizzaDbContext pizzaDbContext) : base(pizzaDbContext)
        {
        }

        public void Delete(int id)
        {
            Pizza pizza = GetPizza(id);

            if (pizza is null)
            {
                throw new Exception($"Pizza with id {id} not found");
            }

            PizzaDatabase.PIZZAS.Remove(pizza);
        }

        public async Task<IReadOnlyList<Pizza>> GetAllPizzasAsync()
        {
            return await GetAll().ToArrayAsync();
        }

        public Pizza GetPizza(int id)
        {
            return PizzaDatabase.PIZZAS.SingleOrDefault(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Pizza>> GetPizzasAsync(int[] pizzaIds)
        {
            return await GetAll().Where(x => pizzaIds.Contains(x.Id)).ToArrayAsync();
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
