using PizzAppOnion.Contracts.ViewModels.Order;

namespace PizzAppOnion.Contracts.Services
{
    public interface IOrderService
    {
        IReadOnlyList<OrderViewModel> GetAllOrders();
    }
}
