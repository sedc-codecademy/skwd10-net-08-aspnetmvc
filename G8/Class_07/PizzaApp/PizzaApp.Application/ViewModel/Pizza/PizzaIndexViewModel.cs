using Model = PizzaApp.Domain.Models;
namespace PizzaApp.Application.ViewModel.Pizza
{
    public class PizzaIndexViewModel
    {
        public IEnumerable<Model.Pizza> Pizzas { get; set; } = new List<Model.Pizza>();

        public IEnumerable<int> Test { get; set; } = new List<int>();

        //public IEnumerable<Cars> Cars { get; set; }

        public string PriceClassName { get; set; } = string.Empty;
    }
}
