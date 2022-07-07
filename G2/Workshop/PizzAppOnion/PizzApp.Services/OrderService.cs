using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Order;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Domain.UnitOfWork;
using PizzAppOnion.Services.Mappers;

namespace PizzAppOnion.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository,
                            IPizzaRepository pizzaRepository,
                            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrderAsync(OrderViewModel order)
        {
            var pizzas = await _pizzaRepository.GetPizzasAsync(order.Pizzas);

            Order createdOrder = new()
            {
                CreatedAt = order.CreatedAt,
                Pizzas = pizzas.ToList()
            };

            _orderRepository.Insert(createdOrder);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            _orderRepository.Delete(id);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<OrderViewModel>> GetAllOrdersAsync()
        {
            IReadOnlyList<Order> dbOrders = await _orderRepository.GetAllOrdersAsync();

            return dbOrders.Select(x => x.ToOrderViewModel()).ToArray();
        }

        public async Task<OrderViewModel> GetOrderAsync(int id)
        {
            Order order = await GetOrderByIdAsync(id);

            return order.ToOrderViewModel();
        }

        public async Task UpdateOrderAsync(int id, OrderViewModel order)
        {
            Order existingOrder = await GetOrderByIdAsync(id);

            var pizzas = await _pizzaRepository.GetPizzasAsync(order.Pizzas);

            existingOrder.CreatedAt = order.CreatedAt;
            existingOrder.Pizzas = pizzas.ToList();

            _orderRepository.Update(existingOrder);
        }

        private async Task<Order> GetOrderByIdAsync(int id)
        {
            Order order = await _orderRepository.GetOrderAsync(id);

            if (order is null)
            {
                throw new Exception("Order not found");
            }

            return order;
        }
    }
}
