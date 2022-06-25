namespace PizzaApp1.Models.ViewModel
{
    public class OrderCreateViewModel
    {
        public IEnumerable<SelectPizzaItem> Pizzas { get; set; } = new List<SelectPizzaItem>();
    }

    public class SelectPizzaItem
    {
        public string Value { get; set; } = string.Empty;

        public bool IsSelected => Value == "on";

        public int PizzaId { get; set; }

        public int NumberOfPizzas { get; set; }
    }
}
