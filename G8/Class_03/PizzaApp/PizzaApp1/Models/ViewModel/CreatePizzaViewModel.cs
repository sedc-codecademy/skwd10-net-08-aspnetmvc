using PizzaApp1.Models.Enums;

namespace PizzaApp1.Models.ViewModel
{
    public class CreatePizzaViewModel
    {
        public IEnumerable<PizzaSize> Sizes { get; set; } = new List<PizzaSize>();
    }
}
