using PizzaApp1.Models.Domain;

namespace PizzaApp1.Models.ViewModel
{
    public class PizzaIndexViewModel
    {
        public IEnumerable<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public IEnumerable<int> Test { get; set; } = new List<int>();

        public string PriceClassName { get; set; } = string.Empty;
    }
}
