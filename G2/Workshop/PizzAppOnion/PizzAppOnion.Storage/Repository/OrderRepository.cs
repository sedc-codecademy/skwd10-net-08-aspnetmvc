using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Storage.Database;

namespace PizzAppOnion.Storage.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IReadOnlyList<Order> GetAllOrders()
        {
            return PizzaDatabase.ORDERS;
        }

        public Order GetOrder(int id)
        {
            return PizzaDatabase.ORDERS.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Order createdOrder)
        {
            createdOrder.Id = PizzaDatabase.GetNextOrderId();

            PizzaDatabase.ORDERS.Add(createdOrder);
        }

        public void Update(Order existingOrder)
        {
            //noop
        }

        public void Delete(int id)
        {
            Order order = GetOrder(id);

            if (order is null)
            {
                throw new Exception($"Order with id {id} not found");
            }

            PizzaDatabase.ORDERS.Remove(order);
        }
    }
}
