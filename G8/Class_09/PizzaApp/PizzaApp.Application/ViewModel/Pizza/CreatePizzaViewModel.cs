using PizzaApp.Domain.Enums;

namespace PizzaApp.Application.ViewModel.Pizza
{
    public class CreatePizzaViewModel
    {
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public PizzaSize Size { get; set; }
    }
}
