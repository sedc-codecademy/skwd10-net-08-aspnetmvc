using PizzaApp.Application.Repository;
using PizzaApp.Domain.Models;

namespace PizzaApp.StaticDb.Repository
{
    public class OrderRepository
        : IOrderRepository
    {
        public Order? GetById(int id)
        {
            return PizzaAppDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public Order Create(Order entity)
        {
            var lastId = PizzaAppDb.Orders.LastOrDefault()?.Id ?? 0;
            entity.Id = ++lastId;
            PizzaAppDb.Orders.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            PizzaAppDb.Orders.Remove(order);
        }

        public void DeleteAll()
        {
            PizzaAppDb.Orders.Clear();
        }

        public IQueryable<Order> GetAll()
        {
            return PizzaAppDb.Orders.AsQueryable();
        }

        public IQueryable<Order> GetAllDileveredPizza()
        {
            return PizzaAppDb.Orders.Where(x => x.IsDelivered.HasValue && x.IsDelivered.Value).AsQueryable();
        }

        public void Update(Order entity)
        {
            var order = GetById(entity.Id);
            order = entity;
        }
    }
}
