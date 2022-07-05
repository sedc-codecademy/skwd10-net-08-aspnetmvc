using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Storage.Database.Context;
using System.Linq;

namespace PizzAppOnion.Storage.Repository
{
    public abstract class RepositoryBase<T> where T : BaseEntity
    {
        protected readonly IPizzaDbContext _pizzaDbContext;

        protected RepositoryBase(IPizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        protected IQueryable<T> GetById(int id)
        {
            return GetAll().Where(x => x.Id == id);
        }

        protected IQueryable<T> GetAll()
        {
            return _pizzaDbContext.Set<T>();
        }

        protected void InsertEntity(T item)
        {
            _pizzaDbContext.Set<T>().Add(item);
        }
    }
}
