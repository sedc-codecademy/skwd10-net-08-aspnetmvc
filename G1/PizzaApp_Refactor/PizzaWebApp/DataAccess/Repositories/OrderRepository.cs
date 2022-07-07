using DataAccess.Abstraction;
using DataAccess.Storage;
using DomainModels;

namespace DataAccess.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        public List<Order> GetAll()
        {
            return PizzaDb.Orders;
        }

        public Order GetById(int id)
        {
            return PizzaDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            PizzaDb.Orders.Add(entity);
        }

        public void Update(Order entity)
        {
            var item = GetById(entity.Id);
            if (item != null)
            {
                int index = PizzaDb.Orders.IndexOf(item);
                PizzaDb.Orders[index] = entity;
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                PizzaDb.Orders.Remove(item);
            }
        }
    }
}
