using PizzAppOnion.Contracts.ViewModels.Order;

namespace PizzAppOnion.Contracts.Services
{
    public interface IOrderService
    {
        IReadOnlyList<OrderViewModel> GetAllOrders();

        OrderViewModel GetOrder(int id);

        void CreateOrder(OrderViewModel order);

        void UpdateOrder(int id, OrderViewModel order);

        void DeleteOrder(int id);
    }
}
