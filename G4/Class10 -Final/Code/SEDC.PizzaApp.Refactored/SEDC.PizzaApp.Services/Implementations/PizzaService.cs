using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.Shared.CustomExceptions;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _pizzaRepository;
        private IRepository<Order> _orderRepository;

        public PizzaService(IPizzaRepository pizzaRepository, IRepository<Order> orderRepository)
        {
            _pizzaRepository = pizzaRepository;
            _orderRepository = orderRepository;
        }

        public string GetMostPopularPizza()
        {
            List<Order> ordersDb = _orderRepository.GetAll();
            //we get list of PizzaOrders connected to any Order
            List<PizzaOrder> pizzaOrders = ordersDb.SelectMany(x => x.PizzaOrders).ToList();
            return pizzaOrders.GroupBy(x => x.PizzaId) //group records by pizza
                   .OrderByDescending(x => x.Count()) //sort the groups by number of records
                   .First()
                   .Select(x => x.Pizza.Name)
                   .First();
        }

        public string GetPizzaOnPromotion()
        {
            var pizzaOnPromotion = _pizzaRepository.GetPizzaOnPromotion();
           
            if(pizzaOnPromotion == null)
            {
                throw new NoPizzaOnPromotionException("No pizza on promotion");
            }
            return pizzaOnPromotion.Name;
        }

        public List<PizzaDDViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();

            return pizzasDb.Select(x => PizzaMapper.ToPizzaDDViewModel(x)).ToList();
        }
    }
}
