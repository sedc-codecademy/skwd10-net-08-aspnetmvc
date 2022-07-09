using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Extensions;
using SEDC.PizzaApp.Services.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            Order order = orderViewModel.MapToOrder();

            // Null coalescing operator
            order.User = userDb ?? throw new Exception($"User with id {orderViewModel.UserId} was not found!");
            _orderRepository.Insert(order);
        }

        public List<OrderListViewModel> GetAllOrders()
        {
            return _orderRepository.GetAll().Select(x => x.MapToOrderListViewModel()).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
