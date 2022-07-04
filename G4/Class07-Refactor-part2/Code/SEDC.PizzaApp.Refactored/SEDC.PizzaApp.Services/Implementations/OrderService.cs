using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Implementations;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.OrderViewModels;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        //repositories are private to the services
        //they are needed in the logic ogf the methods in the services
        //we use interfaces as type!!!
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;

        public OrderService()
        {
            //we assign concrete implementation of the given interface
            _orderRepository = new OrderRepository();
            _userRepository = new UserRepository();
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            //1. validation
            if (string.IsNullOrEmpty(orderViewModel.PizzaStore))
            {
                throw new Exception("PizzaStore can not be empty!");
            }

            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if(userDb == null)
            {
                throw new Exception($"User with id {orderViewModel.UserId} was not found!");
            }

            //2. Map view model to domain model
            Order newOrder = OrderMapper.ToOrder(orderViewModel);
            newOrder.User = userDb;

            //3. Send to the database
            int newOrderId = _orderRepository.Insert(newOrder);
            if(newOrderId <= 0)
            {
                throw new Exception("An error occurred while adding the new order");
            }
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            //1. retrieve the orders from db
            List<Order> ordersDb = _orderRepository.GetAll();

            //2. map from domain models to view models
            List<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();
            foreach(var orderDb in ordersDb)
            {
                OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
                orderDetailsViewModels.Add(orderDetailsViewModel);
            }

            return orderDetailsViewModels;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            //1. try to get the order from db
            Order orderDb = _orderRepository.GetById(id);
            //2. validation
            if(orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            //3. Map the domain model to view model
            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
            return orderDetailsViewModel;
        }
    }
}
