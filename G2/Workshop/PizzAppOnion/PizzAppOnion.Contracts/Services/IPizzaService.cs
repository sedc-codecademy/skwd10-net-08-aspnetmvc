using PizzAppOnion.Contracts.ViewModels.Pizza;

namespace PizzAppOnion.Contracts.Services
{
    public interface IPizzaService
    {
        IReadOnlyList<PizzaViewModel> GetPizzas();
    }
}
