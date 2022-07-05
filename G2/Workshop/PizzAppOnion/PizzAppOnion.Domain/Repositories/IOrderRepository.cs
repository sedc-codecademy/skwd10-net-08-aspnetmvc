using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Domain.Repositories
{
    public interface IOrderRepository
    {
        IReadOnlyList<Order> GetAllOrders();

        Order GetOrder(int id);
        
        void Insert(Order createdOrder);
        
        void Update(Order existingOrder);

        void Delete(int id);
    }
}
