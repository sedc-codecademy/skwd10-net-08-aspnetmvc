namespace PizzaApp.Application.ViewModel
{
    public class OrderEditViewModel
    {
        public int Id { get; set; }

        public List<SelectPizzaEditItem> Pizzas { get; set; } = new List<SelectPizzaEditItem>();
    }
    public class SelectPizzaEditItem
    {
        public bool IsSelected { get; set; }

        public int PizzaId { get; set; }

        public int NumberOfPizzas { get; set; }
    }
}
