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
        private readonly IPizzaRepository _pizzaRepository;

        public OrderService(IOrderRepository orderRepository,
                            IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }

        public void CreateOrder(OrderViewModel order)
        {
            Pizza pizza = _pizzaRepository.GetPizza(order.PizzaId);

            Order createdOrder = new()
            {
                CreatedAt = order.CreatedAt,
                Pizzas = new List<Pizza>()
                {
                    pizza
                }
            };

            _orderRepository.Insert(createdOrder);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        public IReadOnlyList<OrderViewModel> GetAllOrders()
        {
            IReadOnlyList<Order> dbOrders = _orderRepository.GetAllOrders();

            return dbOrders.Select(x => x.ToOrderViewModel()).ToArray();
        }

        public OrderViewModel GetOrder(int id)
        {
            Order order = GetOrderById(id);

            return order.ToOrderViewModel();
        }

        public void UpdateOrder(int id, OrderViewModel order)
        {
            Order existingOrder = GetOrderById(id);

            Pizza pizza = _pizzaRepository.GetPizza(order.PizzaId);

            existingOrder.CreatedAt = order.CreatedAt;
            existingOrder.Pizzas = new List<Pizza>() { pizza };

            _orderRepository.Update(existingOrder);
        }

        private Order GetOrderById(int id)
        {
            Order order = _orderRepository.GetOrder(id);

            if (order is null)
            {
                throw new Exception("Order not found");
            }

            return order;
        }
    }
}
