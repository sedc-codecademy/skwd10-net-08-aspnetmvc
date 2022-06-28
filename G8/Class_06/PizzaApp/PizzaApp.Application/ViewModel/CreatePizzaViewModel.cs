using PizzaApp.Domain.Enums;

namespace PizzaApp.Application.ViewModel
{
    public class CreatePizzaViewModel
    {
        public IEnumerable<PizzaSize> Sizes { get; set; } = new List<PizzaSize>();
    }
}
