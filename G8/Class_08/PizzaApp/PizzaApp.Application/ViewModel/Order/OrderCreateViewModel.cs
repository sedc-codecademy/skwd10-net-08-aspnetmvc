namespace PizzaApp.Application.ViewModel
{
    public class OrderCreateViewModel
    {
        public IEnumerable<SelectPizzaCreateItem> Pizzas { get; set; } = new List<SelectPizzaCreateItem>();
    }

    public class SelectPizzaCreateItem
    {
        public string Value { get; set; } = string.Empty;

        public bool IsSelected => Value == "on";

        public int PizzaId { get; set; }

        public int NumberOfPizzas { get; set; }
    }
}
