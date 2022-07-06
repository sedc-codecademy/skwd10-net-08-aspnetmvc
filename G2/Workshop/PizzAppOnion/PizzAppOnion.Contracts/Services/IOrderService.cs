using PizzAppOnion.Contracts.ViewModels.Order;

namespace PizzAppOnion.Contracts.Services
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderViewModel>> GetAllOrders();

        Task<OrderViewModel> GetOrder(int id);

        Task CreateOrderAsync(OrderViewModel order);

        Task UpdateOrder(int id, OrderViewModel order);

        void DeleteOrder(int id);
    }
}
