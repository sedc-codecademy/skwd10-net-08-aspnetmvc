using DataAccess.Abstraction;
using DomainModels;
using DataAccess.Storage;

namespace DataAccess.Repositories
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public List<Pizza> GetAll()
        {
            return PizzaDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return PizzaDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Pizza entity)
        {
            PizzaDb.Pizzas.Add(entity);
        }

        public void Update(Pizza entity)
        {
            var item = GetById(entity.Id);
            if(item != null)
            {
                int index = PizzaDb.Pizzas.IndexOf(item);
                PizzaDb.Pizzas[index] = entity;
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if(item != null)
            {
                PizzaDb.Pizzas.Remove(item);
            }
        }
    }
}
