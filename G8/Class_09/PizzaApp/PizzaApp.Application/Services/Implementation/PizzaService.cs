using PizzaApp.Application.Mapper;
using PizzaApp.Application.Repository;
using PizzaApp.Application.ViewModel.Pizza;
using PizzaApp.Domain.Enums;
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> repository;

        public PizzaService(IRepository<Pizza> repository)
        {
            this.repository = repository;
        }
        public PizzaViewModel GetPizza(int id)
        {
            var pizza = repository.GetById(id);

            if(pizza == null)
            {
                throw new Exception("Pizza not found");
            }
            return pizza.ToPizzaViewModel();
        }
        public PizzaViewModel CreatePizza(CreatePizzaViewModel model)
        {
            var pizza = model.ToPizza();

            var saved = repository.Create(pizza);
            return saved.ToPizzaViewModel();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public PizzaViewModel EditPizza(PizzaViewModel model, int id)
        {
            var pizza = repository.GetById(id);

            if (pizza == null)
            {
                throw new Exception("Pizza not found");
            }
            var toSave = pizza.Edit(model);

            repository.Update(toSave);

            return toSave.ToPizzaViewModel();
        }

        public IList<PizzaViewModel> GetAllPizza()
        {
            return repository.GetAll().Select(x => x.ToPizzaViewModel()).ToList();
        }

        public IEnumerable<PizzaSize> GetPizzaSizes()
        {
            yield return PizzaSize.Small;
            yield return PizzaSize.Medium;
            yield return PizzaSize.Large;
        }
    }
}
