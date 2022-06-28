
using PizzaApp.Domain.Models;

namespace PizzaApp.Application.ViewModel
{
    public class PizzaIndexViewModel
    {
        public IEnumerable<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public IEnumerable<int> Test { get; set; } = new List<int>();

        //public IEnumerable<Cars> Cars { get; set; }

        public string PriceClassName { get; set; } = string.Empty;
    }
}
