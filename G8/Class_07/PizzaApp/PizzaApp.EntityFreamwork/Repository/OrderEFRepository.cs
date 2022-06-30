using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;


namespace PizzaApp.EntityFreamwork.Repository
{
    public class OrderEFRepository
        : IRepository<Order>
    {
        public Order Create(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
