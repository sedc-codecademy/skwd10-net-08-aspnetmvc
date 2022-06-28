using PizzaApp.Application.Mapper;
using PizzaApp.Application.Repository;
using PizzaApp.Application.ViewModel.Pizza;
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
        public IList<PizzaViewModel> GetAllPizza()
        {
            return repository.GetAll().Select(x => x.ToPizzaViewModel()).ToList();
        }
    }
}
