using PizzaApp.Application.ViewModel.Pizza;
using PizzaApp.Domain.Enums;

namespace PizzaApp.Application.Services
{
    public interface IPizzaService
    {
        IList<PizzaViewModel> GetAllPizza();

        PizzaViewModel GetPizza(int id);

        PizzaViewModel CreatePizza(CreatePizzaViewModel model);

        PizzaViewModel EditPizza(PizzaViewModel model, int id);

        void Delete(int id);

        IEnumerable<PizzaSize> GetPizzaSizes();
    }
}