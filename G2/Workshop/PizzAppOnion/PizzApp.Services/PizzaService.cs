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

        public void CreatePizza(PizzaViewModel pizza)
        {
            Pizza newPizza = new Pizza()
            {
                Name = pizza.Name,
                Price = pizza.Price,
                IsOnPromotion = pizza.IsOnPromotion
            };

            _pizzaRepository.Insert(newPizza);
        }

        public void DeletePizza(int id)
        {
            _pizzaRepository.Delete(id);
        }

        public async Task<IReadOnlyList<PizzaViewModel>> GetAllPizzasAsync()
        {
            IReadOnlyList<Pizza> pizzas = await _pizzaRepository.GetAllPizzasAsync();

            return pizzas.Select(x => x.ToPizzaViewModel()).ToArray();
        }

        public PizzaViewModel GetPizza(int id)
        {
            Pizza pizza = GetPizzaById(id);

            return pizza.ToPizzaViewModel();
        }

        public void UpdatePizza(int id, PizzaViewModel pizza)
        {
            Pizza existingPizza = GetPizzaById(id);

            existingPizza.Price = pizza.Price;
            existingPizza.IsOnPromotion = pizza.IsOnPromotion;
            existingPizza.Name = pizza.Name;

            _pizzaRepository.Update(existingPizza);
        }

        private Pizza GetPizzaById(int id)
        {
            Pizza pizza = _pizzaRepository.GetPizza(id);

            if (pizza is null)
            {
                throw new Exception($"Pizza with id {id} not found");
            }

            return pizza;
        }
    }
}
