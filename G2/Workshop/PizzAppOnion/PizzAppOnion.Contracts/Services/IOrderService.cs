using PizzAppOnion.Contracts.ViewModels.Order;

namespace PizzAppOnion.Contracts.Services
{
    public interface IOrderService
    {
        Task<IReadOnlyList<OrderViewModel>> GetAllOrdersAsync();

        Task<OrderViewModel> GetOrderAsync(int id);

        Task CreateOrderAsync(OrderViewModel order);

        Task UpdateOrderAsync(int id, OrderViewModel order);

        Task DeleteOrderAsync(int id);
    }
}
