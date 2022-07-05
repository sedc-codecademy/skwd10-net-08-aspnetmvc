using PizzAppOnion.Domain.Entities;

namespace PizzAppOnion.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetAllOrdersAsync();

        Task<Order> GetOrderAsync(int id);
        
        void Insert(Order createdOrder);
        
        void Update(Order existingOrder);

        void Delete(int id);
    }
}
