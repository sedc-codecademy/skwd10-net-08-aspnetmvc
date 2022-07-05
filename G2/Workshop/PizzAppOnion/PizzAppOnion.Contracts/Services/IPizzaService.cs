using PizzAppOnion.Contracts.ViewModels.Pizza;

namespace PizzAppOnion.Contracts.Services
{
    public interface IPizzaService
    {
        IReadOnlyList<PizzaViewModel> GetAllPizzas();

        PizzaViewModel GetPizza(int id);

        void CreatePizza(PizzaViewModel pizza);

        void UpdatePizza(int id, PizzaViewModel pizza);

        void DeletePizza(int id);
    }
}
