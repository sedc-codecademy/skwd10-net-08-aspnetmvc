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
    }
}
