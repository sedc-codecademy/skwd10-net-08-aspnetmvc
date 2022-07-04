using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        T? GetById(int id);

        IQueryable<T> GetAll();

        void Update(T entity);

        void Delete(int id);

        T Create(T entity);

        void DeleteAll();
    }
}
