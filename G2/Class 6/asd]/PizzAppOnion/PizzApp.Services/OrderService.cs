using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Order;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Services.Mappers;

namespace PizzAppOnion.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IReadOnlyList<OrderViewModel> GetAllOrders()
        {
            IReadOnlyList<Order> dbOrders = _orderRepository.GetAllOrders();

            return dbOrders.Select(x => x.ToOrderViewModel()).ToArray();
        }
    }
}
