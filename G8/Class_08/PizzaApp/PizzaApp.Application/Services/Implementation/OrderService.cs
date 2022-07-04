using PizzaApp.Application.Mapper;
using PizzaApp.Application.Repository;
using PizzaApp.Application.Services.ExternalServices;
using PizzaApp.Application.ViewModel;
using PizzaApp.Application.ViewModel.Order;
using PizzaApp.Domain.Models;


namespace PizzaApp.Application.Services.Implementation
{
    public class OrderService
        : IOrderService
    {
        private readonly IRepository<Order> repository;
        private readonly IRepository<Pizza> pizzaRepository;
        private readonly IEmailSender emailSender;

        public OrderService(IRepository<Order> repository, IRepository<Pizza> pizzaRepository, IEmailSender emailSender)
        {
            this.repository = repository;
            this.pizzaRepository = pizzaRepository;
            this.emailSender = emailSender;
        }

        public OrderViewModel CreateOrder(OrderCreateViewModel model, User user)
        {
            var selectedPizzas = model.Pizzas.Where(x => x.IsSelected);

            var orderedPizzas = new List<Pizza>();
            foreach (var pizza in selectedPizzas)
            {
                var pizzaModel = pizzaRepository.GetById(pizza.PizzaId);
                if (pizzaModel == null)
                    throw new Exception("Pizza doesn't exist");


                Enumerable.Range(0, pizza.NumberOfPizzas).ToList().ForEach(_ =>
                {
                    orderedPizzas.Add(pizzaModel);
                });

            }

            var order = new Order(user, orderedPizzas);

            repository.Create(order);
            emailSender.SendEmailAsync(user.Email, "Thanks for ordering");
            return order.ToViewModel();
        }

        public OrderViewModel GetOrder(int id)
        {
            var order = repository.GetById(id);

            if (order == null)
            {
                throw new ArgumentException(nameof(order));
            }

            return order.ToViewModel();
        }

        public void EditOrder(int id, OrderEditViewModel model)
        {
            var order = repository.GetById(id);
            if (order == null)
            {
                throw new ArgumentException(nameof(order));
            }

            order.ClearPizzas();

            foreach (var pizzaModel in model.Pizzas.Where(x => x.IsSelected))
            {
                var pizza = pizzaRepository.GetById(pizzaModel.PizzaId);
                order.AddPizza(pizza, pizzaModel.NumberOfPizzas);
            }
        }
    }
}
