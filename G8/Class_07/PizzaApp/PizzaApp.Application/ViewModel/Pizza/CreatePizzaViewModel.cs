using PizzaApp.Domain.Enums;

namespace PizzaApp.Application.ViewModel.Pizza
{
    public class CreatePizzaViewModel
    {
        public IEnumerable<PizzaSize> Sizes { get; set; } = new List<PizzaSize>();
    }
}
