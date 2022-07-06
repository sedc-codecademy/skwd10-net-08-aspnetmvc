using PizzAppOnion.Contracts.Services;
using PizzAppOnion.Contracts.ViewModels.Pizza;
using PizzAppOnion.Domain.Entities;
using PizzAppOnion.Domain.Repositories;
using PizzAppOnion.Services.Mappers;

namespace PizzAppOnion.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public IReadOnlyList<PizzaViewModel> GetPizzas()
        {
            IReadOnlyList<Pizza> pizzas = _pizzaRepository.GetAllPizzas();

            return pizzas.Select(x => x.ToPizzaViewModel()).ToArray();
        }
    }
}
