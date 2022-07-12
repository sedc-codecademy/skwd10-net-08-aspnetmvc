using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Extensions;
using SEDC.PizzaApp.Services.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;

namespace SEDC.PizzaApp.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IPizzaRepository _pizzaRepository;


        public OrderService(IRepository<Order> orderRepository, IRepository<User> userRepository, IPizzaRepository pizzaRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
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

        public OrderDetailsViewModel GetOrderById(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            return orderDb.MapToOrderDetailsViewModel();
        }

        public void AddPizzaToOrder(PizzaOrderViewModel pizzaOrderViewModel)
        {
            Pizza pizzaDb = _pizzaRepository.GetById(pizzaOrderViewModel.PizzaId);
            if (pizzaDb == null)
            {
                // We can add loggs here
                throw new Exception($"Pizza with id {pizzaOrderViewModel.PizzaId} was not found");
            }
            Order orderDb = _orderRepository.GetById(pizzaOrderViewModel.OrderId);
            if (orderDb == null)
            {
                // We can add loggs here
                throw new Exception($"Order with id {pizzaOrderViewModel.OrderId} was not found");
            }

            orderDb.PizzaOrders.Add(new PizzaOrder
            {
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
            });
            _orderRepository.Update(orderDb);
        }
        public OrderViewModel GetOrderForEditing(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }

            return orderDb.MapToOrderViewModel();
        }

        public void EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderViewModel.Id} was not found!");
            }
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if (userDb == null)
            {
                throw new Exception($"The user with id {orderViewModel.UserId} was not found!");
            }

            orderDb.User = userDb;

            orderDb.IsDelivered = orderViewModel.IsDelivered;
            orderDb.PaymentMethod = orderViewModel.PaymentMethod;
            orderDb.Location = orderViewModel.Location;
            _orderRepository.Update(orderDb);
        }

        public void DeleteOrder(int id)
        {
            Order orderDb = _orderRepository.GetById(id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            _orderRepository.Delete(id);
        }
    }
}
