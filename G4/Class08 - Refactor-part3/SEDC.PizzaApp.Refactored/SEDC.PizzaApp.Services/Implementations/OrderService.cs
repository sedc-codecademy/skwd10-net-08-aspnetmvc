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
        private IRepository<Pizza> _pizzaRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<User> userReposiotry, IRepository<Pizza> pizzaRepository)
        {
            ////we assign concrete implementation of the given interface
            //_orderRepository = new OrderRepository();
            //_userRepository = new UserRepository();

            _orderRepository = orderRepository;
            _userRepository = userReposiotry;
            _pizzaRepository = pizzaRepository;
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

            //====using normal mapper method=====
            //Order newOrder = OrderMapper.ToOrder(orderViewModel);

            //====uing extension method=========
            Order newOrder = orderViewModel.ToOrder();
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


        public void AddPizzaToOrder(AddPizzaViewModel addPizzaViewModel)
        {
            //1. validation
            Order orderDb = _orderRepository.GetById(addPizzaViewModel.OrderId);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {addPizzaViewModel.OrderId} was not found!");
            }

            Pizza pizzaDb = _pizzaRepository.GetById(addPizzaViewModel.PizzaId);
            if (pizzaDb == null)
            {
                throw new Exception($"The pizza with id {addPizzaViewModel.PizzaId} was not found!");
            }

            if(addPizzaViewModel.NumberOfPizzas <=0 || addPizzaViewModel.Price <= 0)
            {
                throw new Exception("The price and number of pizzas must be greater than zero!");
            }

            //2. update the order
            //we use one of the main entities
            orderDb.PizzaOrders.Add(new PizzaOrder
            {
                OrderId = orderDb.Id,
                Order = orderDb,
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                NumberOfPizzas = addPizzaViewModel.NumberOfPizzas,
                PizzaSize = addPizzaViewModel.PizzaSize,
                Price = addPizzaViewModel.Price
            });
            _orderRepository.Update(orderDb);
        }

        public void DeleteOrder(int orderId)
        {
            //1. validation 
            Order orderDb = _orderRepository.GetById(orderId);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderId} was not found!");
            }

            //2. delete
            _orderRepository.DeleteById(orderId);
        }
    }
}
