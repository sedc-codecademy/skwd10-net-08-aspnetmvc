using PizzaApp.Application.ViewModel.Pizza;

namespace PizzaApp.Application.Services
{
    public interface IPizzaService
    {
        IList<PizzaViewModel> GetAllPizza();
    }
}