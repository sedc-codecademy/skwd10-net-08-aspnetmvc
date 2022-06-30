using PizzaApp.Application.ViewModel.Pizza;

namespace PizzaApp.Application.ViewModel.Order
{
    public class OrderEditViewModel
    {
        public int Id { get; set; }

        public IList<SelectPizzaItem> Pizzas { get; set; } = new List<SelectPizzaItem>();
    }
}
