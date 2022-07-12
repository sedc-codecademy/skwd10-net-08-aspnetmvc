using SEDC.PizzaApp.DataAccess.Repositories.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Extensions;
using SEDC.PizzaApp.Services.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.PizzaViewModels;

namespace SEDC.PizzaApp.Services.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public List<PizzaViewModel> GetPizzasOnPromotion()
        {
            return _pizzaRepository
                    .GetOnPromotion()
                    .Select(x => x.MapToPizzaViewModel()).ToList(); 
        }
        public List<PizzaViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzasDb = _pizzaRepository.GetAll();

            return pizzasDb.Select(x => x.MapToPizzaViewModel()).ToList();
        }

    }
}
