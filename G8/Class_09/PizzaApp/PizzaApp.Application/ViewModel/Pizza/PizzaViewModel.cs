using PizzaApp.Domain.Enums;

namespace PizzaApp.Application.ViewModel.Pizza
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public PizzaSize Size { get; set; }

        public double Price { get; set; }
    }
}
