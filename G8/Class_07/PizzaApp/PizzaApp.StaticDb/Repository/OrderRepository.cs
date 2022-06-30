using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;

namespace PizzaApp.StaticDb.Repository
{
    public class OrderRepository
        : IOrderRepository
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

        public IQueryable<Order> GetAllDileveredPizza()
        {
            throw new NotImplementedException();
        }

        public Order? GetById(int id)
        {
            return PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
